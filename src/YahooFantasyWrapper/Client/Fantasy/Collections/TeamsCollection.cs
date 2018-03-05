using System.Collections.Generic;
using System.Threading.Tasks;
using YahooFantasyWrapper.Models;

namespace YahooFantasyWrapper.Client
{
    /// <summary>
    /// https://developer.yahoo.com/fantasysports/guide/#teams-collection
    /// With the Teams API, you can obtain information from a collection of teams simultaneously. 
    /// The teams collection is qualified in the URI by a particular league to obtain information about teams within the league, 
    /// or by a particular user (and optionally, a game) to obtain information about the teams owned by the user.
    /// Each element beneath the Teams Collection will be a Team Resource
    /// </summary>
    public class TeamsCollectionManager
    {
        /// <summary>
        /// Gets Teams Collection based on supplied Keys
        /// Attaches Requested SubResources
        /// </summary>
        /// <param name="teamKeys">Teams Keys to return Resources for </param>
        /// <param name="subresources">SubResources to include with Team Resource</param>
        /// <param name="AccessToken">Token for request</param>
        /// <returns>Team Collection (List of Team Resources)</returns>
        public async Task<List<Team>> GetTeams(string[] teamKeys, EndpointSubResourcesCollection subresources, string AccessToken)
        {
            return await Utils.GetCollection<Team>(ApiEndpoints.TeamsEndPoint(teamKeys, subresources), AccessToken, "team");
        }

        /// <summary>
        /// Gets Teams Collection based on supplied league Keys
        /// Attaches Requested SubResources
        /// </summary>
        /// <param name="leagueKeys">League Keys to return Resources for </param>
        /// <param name="subresources">SubResources to include with Team Resource</param>
        /// <param name="AccessToken">Token for request</param>
        /// <returns>Team Collection (List of Team Resources)</returns>
        public async Task<List<League>> GetLeagueTeams(string AccessToken, string[] leagueKeys = null, EndpointSubResourcesCollection subresources = null)
        {
            return await Utils.GetCollection<League>(ApiEndpoints.TeamsLeagueEndPoint(leagueKeys, subresources), AccessToken, "league");
        }

        /// <summary>
        /// Gets Teams Collection based on supplied game Keys for logged in user
        /// Attaches Requested SubResources
        /// </summary>
        /// <param name="gameKeys">Game Keys to return Resources for </param>
        /// <param name="subresources">SubResources to include with Team Resource</param>
        /// <param name="AccessToken">Token for request</param>
        /// <returns>Team Collection (List of Team Resources)</returns>
        public async Task<List<Game>> GetUserGamesTeams(string AccessToken, string[] gameKeys = null, EndpointSubResourcesCollection subresources = null)
        {
            return await Utils.GetCollection<Game>(ApiEndpoints.TeamsUserGamesEndPoint(gameKeys, subresources), AccessToken, "game");
        }
    }
}
