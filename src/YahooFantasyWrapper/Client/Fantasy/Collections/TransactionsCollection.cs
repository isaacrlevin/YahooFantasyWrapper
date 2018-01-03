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
    /// <summary>
    /// https://developer.yahoo.com/fantasysports/guide/#transactions-collection
    /// With the Transactions API, you can obtain information via GET from a collection of transactions simultaneously. 
    /// The transactions collection is qualified in the URI by a particular league.
    /// Each element beneath the Transactions Collection will be a Transaction Resource
    /// </summary>
    public class TransactionsCollectionManager
    {
        /// <summary>
        /// Gets Transactions Collection based on supplied Keys
        /// Attaches Requested SubResources
        /// </summary>
        /// <param name="transactionKeys">Transaction Keys to return Resources for </param>
        /// <param name="subresources">SubResources to include with Transaction Resource</param>
        /// <param name="AccessToken">Token for request</param>
        /// <returns>Transaction Collection (List of Transaction Resources)</returns>
        public async Task<List<Transaction>> GetTransactions(string[] transactionKeys, EndpointSubResourcesCollection subresources, string AccessToken)
        {
            return await Utils.GetCollection<Transaction>(ApiEndpoints.TransactionsEndPoint(transactionKeys, subresources), AccessToken, "transaction");
        }

        /// <summary>
        /// Gets Transactions Collection based on supplied league Keys
        /// Attaches Requested SubResources
        /// </summary>
        /// <param name="leagueKeys">League Keys to return Resources for </param>
        /// <param name="subresources">SubResources to include with Transaction Resource</param>
        /// <param name="AccessToken">Token for request</param>
        /// <returns>Transaction Collection (List of Transaction Resources)</returns>
        public async Task<List<Transaction>> GetTransactionsLeagues(string[] leagueKeys, EndpointSubResourcesCollection subresources, string AccessToken)
        {
            return await Utils.GetCollection<Transaction>(ApiEndpoints.TransactionsLeagueEndPoint(leagueKeys, subresources), AccessToken, "transaction");
        }
        /// <summary>
        /// Adds Player
        /// TODO
        /// </summary>
        /// <param name="gameKeys"></param>
        /// <param name="subresources"></param>
        /// <param name="AccessToken"></param>
        /// <returns></returns>
        public async Task<List<Transaction>> AddPlayer(string[] gameKeys, EndpointSubResourcesCollection subresources, string AccessToken)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Drops Player
        /// TODO
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <param name="gameKeys"></param>
        /// <param name="subresources"></param>
        /// <returns></returns>
        public async Task<List<Transaction>> DropPlayer(string AccessToken, string[] gameKeys = null, EndpointSubResourcesCollection subresources = null)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add/Drops Players
        /// TODO
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <param name="gameKeys"></param>
        /// <param name="subresources"></param>
        /// <returns></returns>
        public async Task<List<Transaction>> AddDropPlayer(string AccessToken, string[] gameKeys = null, EndpointSubResourcesCollection subresources = null)
        {
            throw new NotImplementedException();
        }
    }
}
