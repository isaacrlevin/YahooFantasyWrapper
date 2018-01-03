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
        /// https://fantasysports.yahooapis.com/fantasy/v2/game/{playerKey}/metadata
        /// </summary>
        /// <param name="playerKey">List of LeagueKey to Query</param>
        /// <param name="AccessToken">Access Token from Auth Api</param>
        /// <returns>List of Leagues</returns>
        public async Task<Player> GetMeta(string playerKey, string AccessToken)
        {
            return await Utils.GetResource<Player>(ApiEndpoints.PlayerEndPoint(playerKey, EndpointSubResources.MetaData), AccessToken, "game");
        }

        public async Task<Player> GetStats(string playerKey, string AccessToken)
        {
            return await Utils.GetResource<Player>(ApiEndpoints.PlayerEndPoint(playerKey, EndpointSubResources.Stats), AccessToken, "game");
        }

        public async Task<Player> GetOwnership(string[] playerKeys, string leagueKeys, string AccessToken)
        {
            return await Utils.GetResource<Player>(ApiEndpoints.PlayerOwnershipEndPoint(playerKeys, leagueKeys), AccessToken, "game");
        }

        public async Task<Player> GetPercentOwned(string playerKey, string AccessToken)
        {
            return await Utils.GetResource<Player>(ApiEndpoints.PlayerEndPoint(playerKey, EndpointSubResources.PercentOwned), AccessToken, "game");
        }

        public async Task<Player> GetDraftAnalysis(string playerKey, string AccessToken)
        {
            return await Utils.GetResource<Player>(ApiEndpoints.PlayerEndPoint(playerKey, EndpointSubResources.DraftAnalysis), AccessToken, "game");
        }
    }
}
