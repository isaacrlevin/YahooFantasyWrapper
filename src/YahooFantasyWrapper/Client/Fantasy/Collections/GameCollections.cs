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
    public class GameCollectionsManager
    {
        public async Task<List<Game>> GetGames(string[] gameKeys, EndpointSubResourcesCollection subresources, string AccessToken, GameCollectionFilters filters = null)
        {
            return await Utils.GetCollection<Game>(ApiEndpoints.GamesEndPoint(gameKeys, subresources, filters), AccessToken, "game");
        }

        public async Task<List<Game>> GetGamesUsers(string AccessToken, string[] gameKeys = null, EndpointSubResourcesCollection subresources = null, GameCollectionFilters filters = null)
        {
            return await Utils.GetCollection<Game>(ApiEndpoints.GamesUserEndPoint(gameKeys, subresources, filters), AccessToken, "game");
        }
    }
}
