using System;
using System.Collections.Generic;
using System.Text;

namespace YahooFantasyWrapper.Client
{
    internal static class AuthApiEndPoints
    {
        #region OAuth
        /// <summary>
        /// The request authorization endpoint
        /// </summary>
        internal static EndPoint AccessCodeServiceEndpoint
        {
            get
            {
                return new EndPoint
                {
                    BaseUri = "https://api.login.yahoo.com",
                    Resource = "/oauth2/request_auth"
                };
            }
        }

        /// <summary>
        /// The acess token service endpoint
        /// </summary>
        internal static EndPoint AccessTokenServiceEndpoint
        {
            get
            {
                return new EndPoint
                {
                    BaseUri = "https://api.login.yahoo.com",
                    Resource = "/oauth2/get_token"
                };
            }
        }

        /// <summary>
        /// Defines URI of service which allows to obtain information about user which is currently logged in.
        /// </summary>
        internal static EndPoint UserInfoServiceEndpoint
        {
            get
            {
                return new EndPoint
                {
                    BaseUri = "https://social.yahooapis.com",
                    Resource = "/v1/user/{0}/profile?format=json"
                };
            }
        }
        #endregion
    }
}
