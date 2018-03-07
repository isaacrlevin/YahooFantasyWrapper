using System.Collections.Generic;
using System.Threading.Tasks;
using YahooFantasyWrapper.Models;

namespace YahooFantasyWrapper.Client
{
    /// <summary>
    /// https://developer.yahoo.com/fantasysports/guide/#games-collection
    /// With the Games API, you can obtain information from a collection of games simultaneously. 
    /// Each element beneath the Games Collection will be a Game Resource
    /// </summary>
    public class GameCollectionsManager
    {
        /// <summary>
        /// Gets Games Collection based on supplied Keys
        /// Attaches Requested SubResources
        /// Applies Filters if included
        /// </summary>
        /// <param name="gameKey">Game Key to return Resources for </param>
        /// <param name="AccessToken">Token for request</param>
        /// <returns>Games Collection (List of Game Resources)</returns>
        public async Task<List<Game>> GetGames(string gameKey, string AccessToken)
        {
            return await Utils.GetCollection<Game>(ApiEndpoints.GameEndPoint(gameKey), AccessToken, "game");
        }

        /// <summary>
        /// Gets Games Collection based on supplied Keys
        /// Attaches Requested SubResources
        /// Applies Filters if included
        /// </summary>
        /// <param name="gameKeys">Game Keys to return Resources for </param>
        /// <param name="subresources">SubResources to include with Game Resource</param>
        /// <param name="AccessToken">Token for request</param>
        /// <param name="filters">Custom Filter Object on Game</param>
        /// <returns>Games Collection (List of Game Resources)</returns>
        public async Task<List<Game>> GetGames(string[] gameKeys, string AccessToken, EndpointSubResourcesCollection subresources = null, GameCollectionFilters filters = null)
        {
            return await Utils.GetCollection<Game>(ApiEndpoints.GamesEndPoint(gameKeys, subresources, filters), AccessToken, "game");
        }

        /// <summary>
        /// Gets Games Collection based on supplied Keys for logged in user
        /// Attaches Requested SubResources
        /// Applies Filters if included
        /// </summary>
        /// <param name="gameKeys">Game Keys to return Resources for </param>
        /// <param name="subresources">SubResources to include with Game Resource</param>
        /// <param name="AccessToken">Token for request</param>
        /// <param name="filters">Custom Filter Object on Game</param>
        /// <returns>Games Collection (List of Game Resources)</returns>
        public async Task<List<Game>> GetGamesUsers(string AccessToken, string[] gameKeys = null, EndpointSubResourcesCollection subresources = null, GameCollectionFilters filters = null)
        {
            return await Utils.GetCollection<Game>(ApiEndpoints.GamesUserEndPoint(gameKeys, subresources, filters), AccessToken, "game");
        }
    }
}
