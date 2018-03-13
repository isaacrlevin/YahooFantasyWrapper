using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using YahooFantasyWrapper.Client;
using YahooFantasyWrapper.Models;
using YahooFantasyWrapper.Web.Models;

namespace YahooFantasyWrapper.Web.Controllers
{
    [Route("api/[controller]")]
    public class InteractiveController : Controller
    {
        private readonly IYahooAuthClient _authClient;
        private readonly IYahooFantasyClient _fantasyClient;

        public InteractiveController(IYahooAuthClient authClient, IYahooFantasyClient fantasyClient)
        {
            this._authClient = authClient;
            this._fantasyClient = fantasyClient;
        }

        [HttpGet("[action]")]
        public string Login()
        {
            return this._authClient.GetLoginLinkUri();
        }

        [HttpPost("[action]")]
        public async Task<List<Game>> GetGames(string accessToken)
        {
            var user = await this._fantasyClient.UserResourceManager.GetUser(_authClient.Auth.AccessToken);
            var Games = user.GameList.Games
                 .Where(a => a.Type == "full")
                 .OrderBy(a => a.Season)
                 .ToList();

            return Games;
        }

        [HttpGet("[action]")]
        public async Task<List<League>> GetLeagues(string gameKey)
        {
            var user = await this._fantasyClient.UserResourceManager.GetUserGameLeagues(_authClient.Auth.AccessToken, new string[] { gameKey }, EndpointSubResourcesCollection.BuildResourceList(EndpointSubResources.Teams));
            var Games = user.GameList.Games
                    .Where(a => a.GameKey == a.GameKey)
                    .Select(a => a.LeagueList.Leagues).FirstOrDefault();
            return Games;
        }

        [HttpGet("[action]")]
        public async Task<League> GetLeagueMetadata(string leagueKey)
        {
            return await this._fantasyClient.LeagueResourceManager.GetMeta(leagueKey, _authClient.Auth.AccessToken);
        }

        [HttpGet("[action]")]
        public async Task<League> GetLeagueStandings(string leagueKey)
        {
            return await this._fantasyClient.LeagueResourceManager.GetStandings(leagueKey, _authClient.Auth.AccessToken);
        }

        [HttpGet("[action]")]
        public async Task<League> GetLeagueSettings(string leagueKey)
        {
            return await this._fantasyClient.LeagueResourceManager.GetSettings(leagueKey, _authClient.Auth.AccessToken);
        }

        [HttpGet("[action]")]
        public async Task<League> GetLeagueTeams(string leagueKey)
        {
            return await this._fantasyClient.LeagueResourceManager.GetTeams(leagueKey, _authClient.Auth.AccessToken);
        }
    }
}
