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
   public class TeamResourceManager
    {
        /// <summary>
        /// Get Leagues Meta
        /// https://fantasysports.yahooapis.com/fantasy/v2/game/{teamKey}/metadata
        /// </summary>
        /// <param name="teamKey">List of LeagueKey to Query</param>
        /// <param name="AccessToken">Access Token from Auth Api</param>
        /// <returns>List of Leagues</returns>
        public async Task<Team> GetMeta(string teamKey, string AccessToken)
        {
            return await Utils.GetResource<Team>(ApiEndpoints.TeamEndPoint(teamKey, EndpointSubResources.MetaData), AccessToken, "game");
        }

        public async Task<Team> GetStats(string teamKey, string AccessToken)
        {
           return await Utils.GetResource<Team>(ApiEndpoints.TeamEndPoint(teamKey, EndpointSubResources.Stats), AccessToken, "game");
        }

        public async Task<Team> GetStandings(string teamKey, string AccessToken)
        {
            return await Utils.GetResource<Team>(ApiEndpoints.TeamEndPoint(teamKey, EndpointSubResources.Standings), AccessToken, "game");
        }

        public async Task<Team> GetRoster(string teamKey, string AccessToken)
        {
            return await Utils.GetResource<Team>(ApiEndpoints.TeamEndPoint(teamKey, EndpointSubResources.Roster), AccessToken, "game");
        }

        public async Task<Team> GetDraftResults(string teamKey, string AccessToken)
        {
            return await Utils.GetResource<Team>(ApiEndpoints.TeamEndPoint(teamKey, EndpointSubResources.DraftResults), AccessToken, "game");
        }
        public async Task<Team> GetMatchups(string teamKey, string AccessToken)
        {
            return await Utils.GetResource<Team>(ApiEndpoints.TeamEndPoint(teamKey, EndpointSubResources.Matchups), AccessToken, "game");
        }
    }
}
