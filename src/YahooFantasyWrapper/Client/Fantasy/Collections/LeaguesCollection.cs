using System.Collections.Generic;
using System.Threading.Tasks;
using YahooFantasyWrapper.Models;

namespace YahooFantasyWrapper.Client
{
    /// <summary>
    /// https://developer.yahoo.com/fantasysports/guide/#leagues-collection
    /// With the Leagues API, you can obtain information from a collection of leagues simultaneously.
    /// Each element beneath the Leagues Collection will be a League Resource
    /// </summary>
    public class LeaguesCollectionManager
    {
        /// <summary>
        /// Gets Leagues Collection based on supplied Keys
        /// Attaches Requested SubResources
        /// </summary>
        /// <param name="leagueKeys">League Keys to return Resources for </param>
        /// <param name="subresources">SubResources to include with League Resource</param>
        /// <param name="AccessToken">Token for request</param>
        /// <returns>Leagues Collection (List of League Resources)</returns>
        public async Task<List<League>> GetLeagues(string AccessToken, string[] leagueKeys = null, EndpointSubResourcesCollection subresources = null)
        {
            return await Utils.GetCollection<League>(ApiEndpoints.LeaguesEndPoint(leagueKeys, subresources), AccessToken, "league");
        }
    }
}
