using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using YahooFantasyWrapper.Infrastructure;
using YahooFantasyWrapper.Models;

namespace YahooFantasyWrapper.Client
{
    public class UserResourceManager
    {
        #region Users
        /// <summary>
        /// Get User Info from Yahoo Fantasy Scope
        /// </summary>
        /// <param name="AccessToken">Access Token from Auth Api</param>
        /// <returns>User Object</returns>
        public async Task<User> GetUser(string AccessToken)
        {
            return await Utils.GetResource<User>(ApiEndpoints.UserGamesEndPoint, AccessToken, "user");
        }

        public async Task<User> GetUserGameLeagues(string AccessToken, string[] gameKeys = null, EndpointSubResourcesCollection subresources = null)
        {
            return await Utils.GetResource<User>(ApiEndpoints.UserGameLeaguesEndPoint(gameKeys, subresources), AccessToken, "user");
        }

        public async Task<User> GetUserGamesTeamsEndPoint(string AccessToken, string[] gameKeys = null, EndpointSubResourcesCollection subresources = null)
        {
            return await Utils.GetResource<User>(ApiEndpoints.UserGamesTeamsEndPoint(gameKeys, subresources), AccessToken, "user");
        }

        #endregion
    }
}
