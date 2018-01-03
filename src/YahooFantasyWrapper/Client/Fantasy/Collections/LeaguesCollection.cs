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
    public class LeaguesCollectionManager
    {
        public async Task<List<League>> GetLeagues(string AccessToken, string[] leagueKeys = null, EndpointSubResourcesCollection subresources = null)
        {
            return await Utils.GetCollection<League>(ApiEndpoints.LeaguesEndPoint(leagueKeys, subresources), AccessToken, "game");
        }
    }
}
