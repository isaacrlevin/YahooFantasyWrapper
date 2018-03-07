using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YahooFantasyWrapper.Configuration;
using YahooFantasyWrapper.Models;
using YahooFantasyWrapper.Infrastructure;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using System.Collections.Specialized;
using System.Text;
using System.Text.Encodings.Web;

namespace YahooFantasyWrapper.Client
{
    /// <summary>
    /// Client used to interface with authentication mechanism of Yahoo
    /// </summary>
    public class YahooAuthClient : IYahooAuthClient
    {
        private const string AccessTokenKey = "access_token";
        private const string RefreshTokenKey = "refresh_token";
        private const string ExpiresKey = "expires_in";
        private const string TokenTypeKey = "token_type";
        private readonly IRequestFactory _factory;

        private string _userProfileGUID;

        /// <summary>
        /// Guid to represent user from Yahoo Api
        /// </summary>
        public string UserProfileGUID
        {
            get
            {
                return _userProfileGUID;
            }
            private set
            {
                _userProfileGUID = value;
            }
        }
        /// <summary>
        /// Authentication Model that stores auth data (Tokens, Grant Type)
        /// </summary>
        public AuthModel Auth { get; set; }

        private string GrantType { get; set; }

        /// <summary>
        /// Client configuration object.
        /// </summary>
        public IOptions<YahooConfiguration> Configuration { get; private set; }

        public UserInfo UserInfo { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="YahooAuthClient"/> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        /// <param name="configuration">The configuration.</param>
        public YahooAuthClient(IRequestFactory factory, IOptions<YahooConfiguration> configuration)
        {
            _factory = factory;
            Configuration = configuration;
            Auth = new AuthModel();
        }


        /// <summary>
        /// It's required to store the User GUID obtained in the response for further usage
        /// https://developer.yahoo.com/oauth2/guide/flows_authcode/
        /// </summary>
        /// <param name="args"></param>
        protected void AfterGetAccessToken(BeforeAfterRequestArgs args)
        {
            var responseJObject = JObject.Parse(args.Response);
            this.UserProfileGUID = responseJObject.SelectToken("xoauth_yahoo_guid")?.ToString();
        }

        /// <summary>
        /// Obtains user information using OAuth2 service and data provided via callback request.
        /// </summary>
        /// <param name="parameters">Callback request payload (parameters).</param>
        public async Task<UserInfo> GetUserInfo(NameValueCollection parameters)
        {
            GrantType = "authorization_code";
            CheckErrorAndSetState(parameters);
            await QueryAccessToken(parameters);
            return await GetUserInfo();
        }
        /// <summary>
        /// Get User Profile Infor from Yahoo Api
        /// https://social.yahooapis.com/v1/user/{UserProfileGUID}/profile?format=json
        /// </summary>
        /// <returns></returns>
        protected async Task<UserInfo> GetUserInfo()
        {
            string url = string.Format(AuthApiEndPoints.UserInfoServiceEndpoint.Resource, UserProfileGUID);
            var tempEndPoint = new EndPoint
            {
                BaseUri = AuthApiEndPoints.UserInfoServiceEndpoint.BaseUri,
                Resource = url
            };
            var client = _factory.CreateClient(tempEndPoint, new AuthenticationHeaderValue("Bearer", Auth.AccessToken));
            var request = _factory.CreateRequest(tempEndPoint);

            var response = await client.GetAsync(request.RequestUri);

            var result = await response.Content.ReadAsStringAsync();
            var userInfo = JsonConvert.DeserializeObject<UserInfo>(result);
            return userInfo;
        }

        private void CheckErrorAndSetState(NameValueCollection parameters)
        {
            const string errorFieldName = "error";
            var error = parameters[errorFieldName];
            if (!string.IsNullOrWhiteSpace(error))
            {
                throw new UnexpectedResponseException(errorFieldName);
            }
        }

        /// <summary>
        /// Issues query for access token and parses response.
        /// </summary>
        /// <param name="parameters">Callback request payload (parameters).</param>
        private async Task QueryAccessToken(NameValueCollection parameters)
        {
            var client = _factory.CreateClient(AuthApiEndPoints.AccessTokenServiceEndpoint, null);
            var request = _factory.CreateRequest(AuthApiEndPoints.AccessTokenServiceEndpoint, HttpMethod.Post);

            var body = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("client_id", Configuration.Value.ClientId),
                new KeyValuePair<string, string>("client_secret", Configuration.Value.ClientSecret),
                new KeyValuePair<string, string>("grant_type", GrantType)
            };

            if (GrantType == "refresh_token")
            {
                body.Add(new KeyValuePair<string, string>("refresh_token", parameters.GetOrThrowUnexpectedResponse("refresh_token")));
            }
            else
            {
                body.Add(new KeyValuePair<string, string>("code", parameters.GetOrThrowUnexpectedResponse("code")));
                body.Add(new KeyValuePair<string, string>("redirect_uri", Configuration.Value.RedirectUri));
            }

            var response = client.PostAsync(request.RequestUri, new FormUrlEncodedContent(body)).Result;

            AfterGetAccessToken(new BeforeAfterRequestArgs
            {
                Response = await response.Content.ReadAsStringAsync(),
                Parameters = parameters
            });

            Auth.AccessToken = ParseTokenResponse(await response.Content.ReadAsStringAsync(), AccessTokenKey);
            if (String.IsNullOrEmpty(Auth.AccessToken))
                throw new UnexpectedResponseException(AccessTokenKey);

            if (GrantType != "refresh_token")
                Auth.RefreshToken = ParseTokenResponse(await response.Content.ReadAsStringAsync(), RefreshTokenKey);

            Auth.TokenType = ParseTokenResponse(await response.Content.ReadAsStringAsync(), TokenTypeKey);

            if (Int32.TryParse(ParseTokenResponse(await response.Content.ReadAsStringAsync(), ExpiresKey), out int expiresIn))
                Auth.ExpiresAt = DateTime.Now.AddSeconds(expiresIn);
        }

        /// <summary>
        /// Parse Response from Api Call and returns Access Token
        /// </summary>
        /// <param name="response">api response</param>
        /// <param name="key">key for response type</param>
        /// <returns></returns>
        private string ParseTokenResponse(string response, string key)
        {
            if (String.IsNullOrEmpty(response) || String.IsNullOrEmpty(key))
                return null;

            try
            {
                // response can be sent in JSON format
                var token = JObject.Parse(response).SelectToken(key);
                return token?.ToString();
            }
            catch (JsonReaderException)
            {
                // or it can be in "query string" format (param1=val1&param2=val2)
                var collection = System.Web.HttpUtility.ParseQueryString(response);
                return collection[key];
            }
        }
        /// <summary>
        /// Gets Current Token from request
        /// </summary>
        /// <param name="refreshToken">refresh token used for generation of new access token </param>
        /// <param name="forceUpdate">flag to force generation of new access token</param>
        /// <returns>Access Token</returns>
        public async Task<string> GetCurrentToken(string refreshToken = null, bool forceUpdate = false)
        {
            if (!forceUpdate && Auth.ExpiresAt != default(DateTime) && DateTime.Now < Auth.ExpiresAt && !String.IsNullOrEmpty(Auth.AccessToken))
            {
                return Auth.AccessToken;
            }
            else
            {
                NameValueCollection parameters = new NameValueCollection();
                if (!String.IsNullOrEmpty(refreshToken))
                {
                    parameters.Add("refresh_token", refreshToken);
                }
                else if (!String.IsNullOrEmpty(Auth.RefreshToken))
                {
                    parameters.Add("refresh_token", Auth.RefreshToken);
                }
                if (parameters.Count > 0)
                {
                    GrantType = "refresh_token";
                    await QueryAccessToken(parameters);
                    return Auth.AccessToken;
                }
            }
            throw new Exception("Token never fetched and refresh token not provided.");
        }

        /// <summary>
        /// Returns URI of service which should be called in order to start authentication process.
        /// This URI should be used for rendering login link.
        /// </summary>
        /// Any additional information that will be posted back by service.
        public string GetLoginLinkUri()
        {
            var client = _factory.CreateClient(AuthApiEndPoints.AccessCodeServiceEndpoint, null);
            var request = _factory.CreateRequest(AuthApiEndPoints.AccessCodeServiceEndpoint);

            var body = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("response_type", "code"),
                new KeyValuePair<string, string>("client_id", Configuration.Value.ClientId),
                new KeyValuePair<string, string>("client_secret", Configuration.Value.ClientSecret),
                new KeyValuePair<string, string>("redirect_uri", Configuration.Value.RedirectUri)
            };          

            return AddQueryString(request.RequestUri.ToString(), body.ToDictionary(x => x.Key, x => x.Value));
        }

        /// <summary>
        /// Helper Method to Convert QS Params into stirng
        /// </summary>
        /// <param name="uri">Uri to add params to</param>
        /// <param name="queryString">KVPairs that represent QS params</param>
        /// <returns></returns>
        private static string AddQueryString(
          string uri,
          IEnumerable<KeyValuePair<string, string>> queryString)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            if (queryString == null)
            {
                throw new ArgumentNullException(nameof(queryString));
            }

            var anchorIndex = uri.IndexOf('#');
            var uriToBeAppended = uri;
            var anchorText = "";
            // If there is an anchor, then the query string must be inserted before its first occurance.
            if (anchorIndex != -1)
            {
                anchorText = uri.Substring(anchorIndex);
                uriToBeAppended = uri.Substring(0, anchorIndex);
            }

            var queryIndex = uriToBeAppended.IndexOf('?');
            var hasQuery = queryIndex != -1;

            var sb = new StringBuilder();
            sb.Append(uriToBeAppended);
            foreach (var parameter in queryString)
            {
                sb.Append(hasQuery ? '&' : '?');
                sb.Append(UrlEncoder.Default.Encode(parameter.Key));
                sb.Append('=');
                sb.Append(UrlEncoder.Default.Encode(parameter.Value));
                hasQuery = true;
            }

            sb.Append(anchorText);
            return sb.ToString();
        }

        /// <summary>
        /// Resets Auth for Context, this fires when user logs out
        /// </summary>
        public void ClearAuth()
        {
            this.Auth = new AuthModel();
            this.UserInfo = null;
        }
    }
}