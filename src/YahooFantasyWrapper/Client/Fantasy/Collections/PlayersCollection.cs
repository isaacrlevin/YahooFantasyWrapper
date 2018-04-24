using System.Collections.Generic;
using System.Threading.Tasks;
using YahooFantasyWrapper.Models;

namespace YahooFantasyWrapper.Client
{
    /// <summary>
    /// https://developer.yahoo.com/fantasysports/guide/#players-collection
    /// With the Players API, you can obtain information from a collection of players simultaneously. 
    /// To obtains general players information, the players collection can be qualified in the URI by a particular game, league or team. 
    /// To obtain specific league or team related information, the players collection is qualified by the relevant league or team. 
    /// Each element beneath the Players Collection will be a Player Resource
    /// </summary>
    public class PlayersCollectionManager
    {
        /// <summary>
        /// Gets Players Collection based on supplied Keys
        /// Attaches Requested SubResources
        /// </summary>
        /// <param name="playerKeys">Players Keys to return Resources for </param>
        /// <param name="subresources">SubResources to include with Player Resource</param>
        /// <param name="AccessToken">Token for request</param>
        /// <returns>Players Collection (List of Player Resources)</returns>
        public async Task<List<Player>> GetPlayers(string[] playerKeys, EndpointSubResourcesCollection subresources, string AccessToken)
        {
            return await Utils.GetCollection<Player>(ApiEndpoints.PlayersEndPoint(playerKeys, subresources), AccessToken, "player");
        }

        /// <summary>
        /// Gets Players Collection based on supplied league Keys
        /// Attaches Requested SubResources
        /// </summary>
        /// <param name="leagueKeys">League Keys to return Resources for </param>
        /// <param name="subresources">SubResources to include with Player Resource</param>
        /// <param name="AccessToken">Token for request</param>
        /// <returns>Players Collection (List of Player Resources)</returns>
        public async Task<List<League>> GetLeaguePlayers(string[] leagueKeys, string AccessToken, EndpointSubResourcesCollection subresources = null)
        {
            return await Utils.GetCollection<League>(ApiEndpoints.PlayersLeagueEndPoint(leagueKeys, subresources), AccessToken, "league");
        }

        /// <summary>
        /// Gets Players Collection based on supplied team Keys
        /// Attaches Requested SubResources
        /// </summary>
        /// <param name="teamKeys">Team Keys to return Resources for </param>
        /// <param name="subresources">SubResources to include with Player Resource</param>
        /// <param name="AccessToken">Token for request</param>
        /// <returns>Players Collection (List of Player Resources)</returns>
        public async Task<List<Team>> GetTeamPlayers(string AccessToken, string[] teamKeys = null, EndpointSubResourcesCollection subresources = null)
        {
           return await Utils.GetCollection<Team>(ApiEndpoints.PlayersTeamEndPoint(teamKeys, subresources), AccessToken, "team");
        }
    }
}
