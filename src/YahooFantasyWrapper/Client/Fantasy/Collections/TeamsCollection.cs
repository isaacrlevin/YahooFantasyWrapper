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
        public async Task<List<Team>> GetTeams(string[] gameKeys, EndpointSubResourcesCollection subresources, string AccessToken)
        {
            throw new NotImplementedException();
            //return await Utils.GetCollection<Team>(ApiEndpoints.GamesEndPoint(gameKeys, subresources, isAvailable, seasons, gameCodes, gameTypes), AccessToken, "game");
        }

        public async Task<List<Team>> GetLeagueTeams(string AccessToken, string[] gameKeys = null, EndpointSubResourcesCollection subresources = null)
        {
            throw new NotImplementedException();
            //return await Utils.GetCollection<Team>(ApiEndpoints.GamesUserEndPoint(gameKeys, subresources, isAvailable, seasons, gameCodes, gameTypes), AccessToken, "game");
        }

        public async Task<List<Team>> GetUserGamesTeams(string AccessToken, string[] gameKeys = null, EndpointSubResourcesCollection subresources = null)
        {
            throw new NotImplementedException();
            //return await Utils.GetCollection<Team>(ApiEndpoints.GamesUserEndPoint(gameKeys, subresources, isAvailable, seasons, gameCodes, gameTypes), AccessToken, "game");
        }
    }
}
