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
        public async Task<List<Transaction>> GetTransactions(string[] transactionKeys, EndpointSubResourcesCollection subresources, string AccessToken)
        {
            return await Utils.GetCollection<Transaction>(ApiEndpoints.TransactionsEndPoint(transactionKeys, subresources), AccessToken, "transaction");
        }
        public async Task<List<Transaction>> GetTransactionsLeagues(string[] leagueKeys, EndpointSubResourcesCollection subresources, string AccessToken)
        {
            return await Utils.GetCollection<Transaction>(ApiEndpoints.TransactionsLeagueEndPoint(leagueKeys, subresources), AccessToken, "transaction");
        }
        public async Task<List<Transaction>> AddPlayer(string[] gameKeys, EndpointSubResourcesCollection subresources, string AccessToken)
        {
            throw new NotImplementedException();
            //return await Utils.GetCollection<Transaction>(ApiEndpoints.GamesEndPoint(gameKeys, subresources, isAvailable, seasons, gameCodes, gameTypes), AccessToken, "transaction");
        }

        public async Task<List<Transaction>> DropPlayer(string AccessToken, string[] gameKeys = null, EndpointSubResourcesCollection subresources = null)
        {
            throw new NotImplementedException();
            //return await Utils.GetCollection<Transaction>(ApiEndpoints.GamesUserEndPoint(gameKeys, subresources, isAvailable, seasons, gameCodes, gameTypes), AccessToken, "transaction");
        }

        public async Task<List<Transaction>> AddDropPlayer(string AccessToken, string[] gameKeys = null, EndpointSubResourcesCollection subresources = null)
        {
            throw new NotImplementedException();
            //return await Utils.GetCollection<Transaction>(ApiEndpoints.GamesUserEndPoint(gameKeys, subresources, isAvailable, seasons, gameCodes, gameTypes), AccessToken, "transaction");
        }
    }
}
