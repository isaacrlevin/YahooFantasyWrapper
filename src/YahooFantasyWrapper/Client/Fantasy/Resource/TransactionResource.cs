using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace YahooFantasyWrapper.Client
{
    public class TransactionResourceManager
    {
        public async Task<Transaction> GetMeta(string transactionKey, string AccessToken)
        {
            return await Utils.GetResource<Transaction>(ApiEndpoints.TransactionEndpoint(transactionKey, EndpointSubResources.MetaData), AccessToken, "transaction");
        }

        public async Task<Transaction> GetPlayers(string transactionKey, string[] leagueKeys, string AccessToken)
        {
            return await Utils.GetResource<Transaction>(ApiEndpoints.TransactionEndpoint(transactionKey, EndpointSubResources.Players), AccessToken, "transaction");
        }
    }
}
