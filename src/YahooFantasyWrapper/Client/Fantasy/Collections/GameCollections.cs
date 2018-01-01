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
        public async Task<List<Game>> GetGames(string[] gameKeys, EndpointSubResourcesCollection subresources, string AccessToken, bool? isAvailable = null, int[] seasons = null, GameCode[] gameCodes = null, GameType[] gameTypes = null)
        {
            return await Utils.GetCollection<Game>(ApiEndpoints.GamesEndPoint(gameKeys, subresources, isAvailable, seasons, gameCodes, gameTypes), AccessToken, "game");
        }

        public async Task<List<Game>> GetGamesUsers(string AccessToken, string[] gameKeys = null, EndpointSubResourcesCollection subresources = null, bool? isAvailable = null, int[] seasons = null, GameCode[] gameCodes = null, GameType[] gameTypes = null)
        {
            return await Utils.GetCollection<Game>(ApiEndpoints.GamesUserEndPoint(gameKeys, subresources, isAvailable, seasons, gameCodes, gameTypes), AccessToken, "game");
        }
    }
}
