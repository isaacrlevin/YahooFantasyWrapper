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
    public class GameResourceManager
    {
        /// <summary>
        /// Get Games Meta
        /// https://fantasysports.yahooapis.com/fantasy/v2/game/{gameKey}/metadata
        /// </summary>
        /// <param name="gameKey">List of GameKey to Query</param>
        /// <param name="AccessToken">Access Token from Auth Api</param>
        /// <returns>List of Games</returns>
        public async Task<Game> GetMeta(string gameKey, string AccessToken)
        {
            return await Utils.GetResource<Game>(ApiEndpoints.GameMetaDataEndPoint(gameKey), AccessToken, "game");
        }

        public async Task<Game> GetLeagues(string gameKey, string[] leagueKeys, string AccessToken)
        {
            return await Utils.GetResource<Game>(ApiEndpoints.GameLeaguesEndPoint(gameKey, leagueKeys), AccessToken, "game");
        }

        public async Task<Game> GetPlayers(string gameKey, string[] playerKeys, string AccessToken)
        {
            return await Utils.GetResource<Game>(ApiEndpoints.GamePlayersEndPoint(gameKey, playerKeys), AccessToken, "game");
        }

        public async Task<Game> GetGameWeeks(string gameKey, string AccessToken)
        {
            return await Utils.GetResource<Game>(ApiEndpoints.GameGameWeeksEndPoint(gameKey), AccessToken, "game");
        }

        public async Task<Game> GetStatCategories(string gameKey, string AccessToken)
        {
            return await Utils.GetResource<Game>(ApiEndpoints.GameStatCategoriesEndPoint(gameKey), AccessToken, "game");
        }

        public async Task<Game> GetPositionTypes(string gameKey, string AccessToken)
        {
            return await Utils.GetResource<Game>(ApiEndpoints.GamePositionTypesEndPoint(gameKey), AccessToken, "game");
        }

        public async Task<Game> GetRosterPositions(string gameKey, string AccessToken)
        {
            return await Utils.GetResource<Game>(ApiEndpoints.GameRosterPositionsEndPoint(gameKey), AccessToken, "game");
        }
    }
}
