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
   public class PlayerResourceManager
    {
        /// <summary>
        /// Get Leagues Meta
        /// https://fantasysports.yahooapis.com/fantasy/v2/game/{gameKey}/metadata
        /// </summary>
        /// <param name="gameKey">List of LeagueKey to Query</param>
        /// <param name="AccessToken">Access Token from Auth Api</param>
        /// <returns>List of Leagues</returns>
        public async Task<League> GetMeta(string gameKey, string AccessToken)
        {
            throw new NotImplementedException();
            //return await Utils.GetResource<Player>(ApiEndpoints.LeagueMetaDataEndPoint(gameKey), AccessToken, "game");
        }

        public async Task<League> GetStats(string gameKey, string[] leagueKeys, string AccessToken)
        {
            throw new NotImplementedException();
            //return await Utils.GetResource<Player>(ApiEndpoints.LeagueLeaguesEndPoint(gameKey, leagueKeys), AccessToken, "game");
        }

        public async Task<League> GetOwnership(string gameKey, string[] playerKeys, string AccessToken)
        {
            throw new NotImplementedException();
            //return await Utils.GetResource<Player>(ApiEndpoints.LeaguePlayersEndPoint(gameKey, playerKeys), AccessToken, "game");
        }

        public async Task<League> GetPercentOwned(string gameKey, string AccessToken)
        {
            throw new NotImplementedException();
            //return await Utils.GetResource<Player>(ApiEndpoints.LeagueLeagueWeeksEndPoint(gameKey), AccessToken, "game");
        }

        public async Task<League> GetDraftAnalysis(string gameKey, string AccessToken)
        {
            throw new NotImplementedException();
            //return await Utils.GetResource<Player>(ApiEndpoints.LeagueStatCategoriesEndPoint(gameKey), AccessToken, "game");
        }
    }
}
