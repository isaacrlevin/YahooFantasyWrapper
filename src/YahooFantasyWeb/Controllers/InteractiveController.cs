using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using YahooFantasyWeb.Models;
using YahooFantasyWrapper.Client;
using YahooFantasyWrapper.Models;

namespace YahooFantasyWeb.Controllers
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

        [HttpGet]
        public async Task<List<Game>> Get()
        {
            var user = await this._fantasyClient.UserResourceManager.GetUser(_authClient.Auth.AccessToken);
            var Games = user.GameList.Games
                 .Where(a => a.Type == "full")
                 .OrderBy(a => a.Season)
                 .ToList();
            return Games;
        }

        //public async Task<IActionResult> Index()
        //{
        //    InteractiveModel model = new InteractiveModel();
        //    var user = await this._fantasyClient.UserResourceManager.GetUser(_authClient.Auth.AccessToken);
        //    model.Games = user.GameList.Games
        //         .Where(a => a.Type == "full")
        //         .OrderBy(a => a.Season)
        //         .ToList();

        //    return (IActionResult)this.View((object)model);
        //}
    }
}