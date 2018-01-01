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
    public class RosterResourceManager
    {
        public async Task<Roster> GetPlayers(string gameKey, string AccessToken)
        {
            throw new NotImplementedException();
            //return await Utils.GetResource<Player>(ApiEndpoints.LeagueMetaDataEndPoint(gameKey), AccessToken, "game");
        }
    }
}
