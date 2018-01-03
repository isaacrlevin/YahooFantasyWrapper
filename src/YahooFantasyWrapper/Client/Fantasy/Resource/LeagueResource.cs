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
    public class LeagueResourceManager
    {
        /// <summary>
        /// Get Leagues Meta
        /// https://fantasysports.yahooapis.com/fantasy/v2/game/{gameKey}/metadata
        /// </summary>
        /// <param name="gameKey">List of LeagueKey to Query</param>
        /// <param name="AccessToken">Access Token from Auth Api</param>
        /// <returns>List of Leagues</returns>
        public async Task<League> GetMeta(string leagueKey, string AccessToken)
        {
            return await Utils.GetResource<League>(ApiEndpoints.LeagueEndPoint(leagueKey, EndpointSubResources.MetaData), AccessToken, "league");
        }

        public async Task<League> GetSettings(string leagueKey, string AccessToken)
        {
            return await Utils.GetResource<League>(ApiEndpoints.LeagueEndPoint(leagueKey, EndpointSubResources.Settings), AccessToken, "league");
        }

        public async Task<League> GetStandings(string leagueKey, string AccessToken)
        {
            return await Utils.GetResource<League>(ApiEndpoints.LeagueEndPoint(leagueKey, EndpointSubResources.Standings), AccessToken, "league");
        }

        public async Task<League> GetScoreboard(string leagueKey, string AccessToken)
        {
            return await Utils.GetResource<League>(ApiEndpoints.LeagueEndPoint(leagueKey, EndpointSubResources.Scoreboard), AccessToken, "league");
        }

        public async Task<League> GetTeams(string leagueKey, string AccessToken)
        {
            return await Utils.GetResource<League>(ApiEndpoints.LeagueEndPoint(leagueKey, EndpointSubResources.Teams), AccessToken, "league");
        }

        public async Task<League> GetDraftResults(string leagueKey, string AccessToken)
        {
            return await Utils.GetResource<League>(ApiEndpoints.LeagueEndPoint(leagueKey, EndpointSubResources.DraftResults), AccessToken, "league");
        }

        public async Task<League> GetTransactions(string leagueKey, string AccessToken)
        {
            return await Utils.GetResource<League>(ApiEndpoints.LeagueEndPoint(leagueKey, EndpointSubResources.Transactions), AccessToken, "league");
        }
    }
}
