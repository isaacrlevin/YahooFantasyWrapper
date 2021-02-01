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
        public async Task<List<Game>> GetGames([FromBody]PostModel model)
        {
            var user = await this._fantasyClient.UserResourceManager.GetUser(model.AccessToken);
            var Games = user.GameList.Games
                 .Where(a => a.Type == "full")
                 .OrderBy(a => a.Season)
                 .ToList();

            return Games;
        }

        [HttpPost("[action]")]
        public async Task<List<League>> GetLeagues([FromBody] PostModel model)
        {
            var user = await this._fantasyClient.UserResourceManager.GetUserGameLeagues(model.AccessToken, new string[] { model.Key }, EndpointSubResourcesCollection.BuildResourceList(EndpointSubResources.Teams));
            var Games = user.GameList.Games
                    .Where(a => a.GameKey == a.GameKey)
                    .Select(a => a.LeagueList.Leagues).FirstOrDefault();
            return Games;
        }

        [HttpPost("[action]")]
        public async Task<League> GetLeagueMetadata([FromBody] PostModel model)
        {
            return await this._fantasyClient.LeagueResourceManager.GetMeta(model.Key, model.AccessToken);
        }

        [HttpPost("[action]")]
        public async Task<League> GetLeagueStandings([FromBody] PostModel model)
        {
            return await this._fantasyClient.LeagueResourceManager.GetStandings(model.Key, model.AccessToken);
        }

        [HttpPost("[action]")]
        public async Task<League> GetLeagueSettings([FromBody] PostModel model)
        {
            return await this._fantasyClient.LeagueResourceManager.GetSettings(model.Key, model.AccessToken);
        }

        [HttpPost("[action]")]
        public async Task<League> GetLeagueTeams([FromBody] PostModel model)
        {
            return await this._fantasyClient.LeagueResourceManager.GetTeams(model.Key, model.AccessToken);
        }

        [HttpPost("[action]")]
        public async Task<League> GetLeagueScoreboard([FromBody] PostModel model)
        {
            return await this._fantasyClient.LeagueResourceManager.GetScoreboard(model.Key, model.AccessToken);
        }

        [HttpPost("[action]")]
        public async Task<League> GetDraftResults([FromBody] PostModel model)
        {
            return await this._fantasyClient.LeagueResourceManager.GetDraftResults(model.Key, model.AccessToken);
        }
    }
}
