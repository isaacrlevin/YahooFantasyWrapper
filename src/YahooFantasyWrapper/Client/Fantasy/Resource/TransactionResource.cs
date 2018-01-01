using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace YahooFantasyWrapper.Client
{
    public class TransactionResourceManager
    {
        public async Task<Transaction> GetMeta(string gameKey, string AccessToken)
        {
            throw new NotImplementedException();
            //return await Utils.GetResource<Player>(ApiEndpoints.LeagueMetaDataEndPoint(gameKey), AccessToken, "game");
        }

        public async Task<Transaction> GetPlayers(string gameKey, string[] leagueKeys, string AccessToken)
        {
            throw new NotImplementedException();
            //return await Utils.GetResource<Player>(ApiEndpoints.LeagueLeaguesEndPoint(gameKey, leagueKeys), AccessToken, "game");
        }
    }
}
