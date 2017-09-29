using System;
using System.Collections.Generic;
using System.Text;

namespace YahooFantasyWrapper.Client
{
    public static class AuthApiEndPoints
    {
        #region OAuth
        /// <summary>
        /// The request authorization endpoint
        /// </summary>
        public static Endpoint AccessCodeServiceEndpoint
        {
            get
            {
                return new Endpoint
                {
                    BaseUri = "https://api.login.yahoo.com",
                    Resource = "/oauth2/request_auth"
                };
            }
        }

        /// <summary>
        /// The acess token service endpoint
        /// </summary>
        public static Endpoint AccessTokenServiceEndpoint
        {
            get
            {
                return new Endpoint
                {
                    BaseUri = "https://api.login.yahoo.com",
                    Resource = "/oauth2/get_token"
                };
            }
        }

        /// <summary>
        /// Defines URI of service which allows to obtain information about user which is currently logged in.
        /// </summary>
        public static Endpoint UserInfoServiceEndpoint
        {
            get
            {
                return new Endpoint
                {
                    BaseUri = "https://social.yahooapis.com",
                    Resource = "/v1/user/{0}/profile?format=json"
                };
            }
        }
        #endregion
    }
}
