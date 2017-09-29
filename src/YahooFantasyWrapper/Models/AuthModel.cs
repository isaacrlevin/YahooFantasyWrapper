using System;
using System.Collections.Generic;
using System.Text;

namespace YahooFantasyWrapper.Models
{
    /// <summary>
    /// Class to Store Authentication Data for Yahoo
    /// </summary>
   public class AuthModel
    {
        public string AccessToken { get; set; }

        /// <summary>
        /// Refresh token returned by provider. Can be used for further calls of provider API.
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// Token type returned by provider. Can be used for further calls of provider API.
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        /// Seconds till the token expires returned by provider. Can be used for further calls of provider API.
        /// </summary>
        public DateTime ExpiresAt { get; set; }
    }
}
