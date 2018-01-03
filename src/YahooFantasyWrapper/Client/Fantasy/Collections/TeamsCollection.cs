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
    public class TeamsCollectionManager
    {
        public async Task<List<Team>> GetTeams(string[] teamKeys, EndpointSubResourcesCollection subresources, string AccessToken)
        {
            return await Utils.GetCollection<Team>(ApiEndpoints.TeamsEndPoint(teamKeys, subresources), AccessToken, "team");
        }

        public async Task<List<Team>> GetLeagueTeams(string AccessToken, string[] leagueKeys = null, EndpointSubResourcesCollection subresources = null)
        {
            return await Utils.GetCollection<Team>(ApiEndpoints.TeamsLeagueEndPoint(leagueKeys, subresources), AccessToken, "team");
        }

        public async Task<List<Team>> GetUserGamesTeams(string AccessToken, string[] gameKeys = null, EndpointSubResourcesCollection subresources = null)
        {
            return await Utils.GetCollection<Team>(ApiEndpoints.TeamsUserGamesEndPoint(gameKeys, subresources), AccessToken, "team");
        }
    }
}
