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
   public class TransactionsCollectionManager
    {
        public async Task<List<Transaction>> AddPlayer(string[] gameKeys, EndpointSubResourcesCollection subresources, string AccessToken, bool? isAvailable = null, int[] seasons = null, GameCode[] gameCodes = null, GameType[] gameTypes = null)
        {
            throw new NotImplementedException();
            //return await Utils.GetCollection<Team>(ApiEndpoints.GamesEndPoint(gameKeys, subresources, isAvailable, seasons, gameCodes, gameTypes), AccessToken, "game");
        }

        public async Task<List<Transaction>> DropPlayer(string AccessToken, string[] gameKeys = null, EndpointSubResourcesCollection subresources = null, bool? isAvailable = null, int[] seasons = null, GameCode[] gameCodes = null, GameType[] gameTypes = null)
        {
            throw new NotImplementedException();
            //return await Utils.GetCollection<Team>(ApiEndpoints.GamesUserEndPoint(gameKeys, subresources, isAvailable, seasons, gameCodes, gameTypes), AccessToken, "game");
        }

        public async Task<List<Transaction>> AddDropPlayer(string AccessToken, string[] gameKeys = null, EndpointSubResourcesCollection subresources = null, bool? isAvailable = null, int[] seasons = null, GameCode[] gameCodes = null, GameType[] gameTypes = null)
        {
            throw new NotImplementedException();
            //return await Utils.GetCollection<Team>(ApiEndpoints.GamesUserEndPoint(gameKeys, subresources, isAvailable, seasons, gameCodes, gameTypes), AccessToken, "game");
        }
    }
}
