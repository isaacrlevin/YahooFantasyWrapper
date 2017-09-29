using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YahooFantasyWrapper.Models;

namespace YahooFantasyWrapper.Client
{
    public interface IYahooFantasyClient
    {
        Task<User> GetUser(string AccessToken);
        Task<IList<Game>> GetUserGames(string[] gameKeys, EndpointSubResourcesCollection subresources, string AccessToken);
        Task<IList<League>> GetLeagueTeams(string[] leagueKeys, EndpointSubResourcesCollection subresources, string AccessToken);
        Task<IList<League>> GetLeagues(string[] leagueKeys, EndpointSubResourcesCollection subresources, string AccessToken);
    }
}
