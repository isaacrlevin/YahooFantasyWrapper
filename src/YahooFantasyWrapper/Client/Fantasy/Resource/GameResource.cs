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
    /// <summary>
    /// https://developer.yahoo.com/fantasysports/guide/#game-resource
    /// With the Game API, you can obtain the fantasy game related information, like the fantasy game name, the Yahoo! game code, and season.
    /// </summary>
    public class GameResourceManager
    {
        /// <summary>
        /// Get Game Resource with Meta Subresource
        /// https://fantasysports.yahooapis.com/fantasy/v2/game/{gameKey}/metadata
        /// </summary>
        /// <param name="gameKey">GameKey to Query</param>
        /// <param name="AccessToken">Access Token from Auth Api</param>
        /// <returns>Game Resource</returns>
        public async Task<Game> GetMeta(string gameKey, string AccessToken)
        {
            return await Utils.GetResource<Game>(ApiEndpoints.GameEndPoint(gameKey, EndpointSubResources.MetaData), AccessToken, "game");
        }
        /// <summary>
        /// Get Game Resource with Leagues Subresource
        /// https://fantasysports.yahooapis.com/fantasy/v2/game/{gameKey}/leagues
        /// </summary>
        /// <param name="gameKey">GameKey to Query</param>
        /// <param name="AccessToken">Access Token from Auth Api</param>
        /// <returns>Game Resource</returns>
        public async Task<Game> GetLeagues(string gameKey, string[] leagueKeys, string AccessToken)
        {
            return await Utils.GetResource<Game>(ApiEndpoints.GameLeaguesEndPoint(gameKey, leagueKeys), AccessToken, "game");
        }
        /// <summary>
        /// Get Game Resource with Players Subresource
        /// https://fantasysports.yahooapis.com/fantasy/v2/game/{gameKey}/players
        /// </summary>
        /// <param name="gameKey">GameKey to Query</param>
        /// <param name="AccessToken">Access Token from Auth Api</param>
        /// <returns>Game Resource</returns>
        public async Task<Game> GetPlayers(string gameKey, string[] playerKeys, string AccessToken)
        {
            return await Utils.GetResource<Game>(ApiEndpoints.GamePlayersEndPoint(gameKey, playerKeys), AccessToken, "game");
        }
        /// <summary>
        /// Get Game Resource with GameWeeks Subresource
        /// https://fantasysports.yahooapis.com/fantasy/v2/game/{gameKey}/game_weeks
        /// </summary>
        /// <param name="gameKey">GameKey to Query</param>
        /// <param name="AccessToken">Access Token from Auth Api</param>
        /// <returns>Game Resource</returns>
        public async Task<Game> GetGameWeeks(string gameKey, string AccessToken)
        {
            return await Utils.GetResource<Game>(ApiEndpoints.GameEndPoint(gameKey, EndpointSubResources.GameWeeks), AccessToken, "game");
        }
        /// <summary>
        /// Get Game Resource with Stat Categories Subresource
        /// https://fantasysports.yahooapis.com/fantasy/v2/game/{gameKey}/stat_categories
        /// </summary>
        /// <param name="gameKey">GameKey to Query</param>
        /// <param name="AccessToken">Access Token from Auth Api</param>
        /// <returns>Game Resource</returns>
        public async Task<Game> GetStatCategories(string gameKey, string AccessToken)
        {
            return await Utils.GetResource<Game>(ApiEndpoints.GameEndPoint(gameKey, EndpointSubResources.StatCategories), AccessToken, "game");
        }
        /// <summary>
        /// Get Game Resource with Position Types Subresource
        /// https://fantasysports.yahooapis.com/fantasy/v2/game/{gameKey}/position_types
        /// </summary>
        /// <param name="gameKey">GameKey to Query</param>
        /// <param name="AccessToken">Access Token from Auth Api</param>
        /// <returns>Game Resource</returns>
        public async Task<Game> GetPositionTypes(string gameKey, string AccessToken)
        {
            return await Utils.GetResource<Game>(ApiEndpoints.GameEndPoint(gameKey, EndpointSubResources.PositionTypes), AccessToken, "game");
        }
        /// <summary>
        /// Get Game Resource with Roster Positions Subresource
        /// https://fantasysports.yahooapis.com/fantasy/v2/game/{gameKey}/roster_positions
        /// </summary>
        /// <param name="gameKey">GameKey to Query</param>
        /// <param name="AccessToken">Access Token from Auth Api</param>
        /// <returns>Game Resource</returns>
        public async Task<Game> GetRosterPositions(string gameKey, string AccessToken)
        {
            return await Utils.GetResource<Game>(ApiEndpoints.GameEndPoint(gameKey, EndpointSubResources.RosterPositions), AccessToken, "game");
        }
    }
}
