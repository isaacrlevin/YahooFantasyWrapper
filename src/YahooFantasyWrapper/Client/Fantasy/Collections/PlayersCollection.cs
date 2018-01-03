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
    public class PlayersCollectionManager
    {
        public async Task<List<Player>> GetPlayers(string[] playerKeys, EndpointSubResourcesCollection subresources, string AccessToken)
        {
            return await Utils.GetCollection<Player>(ApiEndpoints.PlayersEndPoint(playerKeys, subresources), AccessToken, "game");
        }

        public async Task<List<Player>> GetLeaguePlayers(string[] leagueKeys, string AccessToken, EndpointSubResourcesCollection subresources = null)
        {
            return await Utils.GetCollection<Player>(ApiEndpoints.PlayersLeagueEndPoint(leagueKeys, subresources), AccessToken, "game");
        }

        public async Task<List<Player>> GetTeamPlayers(string AccessToken, string[] teamKeys = null, EndpointSubResourcesCollection subresources = null)
        {
           return await Utils.GetCollection<Player>(ApiEndpoints.PlayersTeamEndPoint(teamKeys, subresources), AccessToken, "game");
        }
    }
}
