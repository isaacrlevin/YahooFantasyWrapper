using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YahooFantasyWrapper.Models;

namespace YahooFantasyWrapper.Client
{
    public interface IYahooFantasyClient
    {
        GameResourceManager GameResourceManager { get; }
        GameCollectionsManager GameCollectionsManager { get; }
        UserResourceManager UserResourceManager { get; }
        LeagueResourceManager LeagueResourceManager { get; }
        LeaguesCollectionManager LeaguesCollectionManager { get; }
        PlayerResourceManager PlayerResourceManager { get; }
        PlayersCollectionManager PlayersCollectionManager { get; }
        RosterResourceManager RosterResourceManager { get; }
        TeamResourceManager TeamResourceManager { get; }
        TeamsCollectionManager TeamsCollectionManager { get; }
        TransactionResourceManager TransactionResourceManager { get; }
        TransactionsCollectionManager TransactionsCollectionManager { get; }
    }
}
