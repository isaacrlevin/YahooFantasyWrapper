using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace YahooFantasyWrapper.Client
{
    /// <summary>
    /// https://developer.yahoo.com/fantasysports/guide/#transaction-resource
    /// With the Transaction API, you can obtain information about transactions (adds, drops, trades, and league settings changes) performed on a league. 
    /// A transaction is identified in the context of a particular league, although you can request a particular Transaction Resource as the base of your URI by using the global ````.
    ///
    /// You can also PUT to the API to perform operations like editing waiver priorities or FAAB bids, or modifying the state of pending trades.
    /// You can also cancel pending transactions by DELETEing them.
    ///
    /// Keep in mind, if you don’t have the ```` for a waiver claim or pending trade, the only way to discover these transactions is to filter the league 
    /// Transactions collection by a particular type(waiver or pending_trade) and by a particular ````. 
    /// Pending transactions will not show up if you simply ask for all of the transactions in the league, because they can only be seen by certain teams.
    /// </summary>
    public class TransactionResourceManager
    {
        /// <summary>
        /// Get Transaction Resource with Meta Subresource
        /// https://fantasysports.yahooapis.com/fantasy/v2/transaction/{transactionKey}/metadata
        /// </summary>
        /// <param name="transactionKey">Transaction Key to Query</param>
        /// <param name="AccessToken">Access Token from Auth Api</param>
        /// <returns>Transaction Resource</returns>
        public async Task<Transaction> GetMeta(string transactionKey, string AccessToken)
        {
            return await Utils.GetResource<Transaction>(ApiEndpoints.TransactionEndpoint(transactionKey, EndpointSubResources.MetaData), AccessToken, "transaction");
        }

        /// <summary>
        /// Get Transaction Resource with Player Subresource
        /// https://fantasysports.yahooapis.com/fantasy/v2/transaction/{transactionKey}/players
        /// </summary>
        /// <param name="transactionKey">Transaction Key to Query</param>
        /// <param name="AccessToken">Access Token from Auth Api</param>
        /// <returns>Transaction Resource</returns>
        public async Task<Transaction> GetPlayers(string transactionKey, string AccessToken)
        {
            return await Utils.GetResource<Transaction>(ApiEndpoints.TransactionEndpoint(transactionKey, EndpointSubResources.Players), AccessToken, "transaction");
        }
    }
}
