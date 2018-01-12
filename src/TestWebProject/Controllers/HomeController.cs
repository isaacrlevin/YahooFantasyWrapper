using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Http;
using YahooFantasyWrapper.Models;
using System.Web;
using TestWebProject.Models;
using YahooFantasyWrapper.Client;

namespace TestWebProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IYahooAuthClient _authClient;
        private readonly IYahooFantasyClient _fantasyClient;

        private NameValueCollection Parameters
        {
            get
            {
                return HttpUtility.ParseQueryString(Request.QueryString.Value);
            }
        }

        public HomeController(IYahooAuthClient authClient, IYahooFantasyClient fantasyClient)
        {
            this._authClient = authClient;
            this._fantasyClient = fantasyClient;
        }

        public async Task<IActionResult> Index()
        {
            ViewModel model = new ViewModel();
            // By default, Yahoo! sends a QS param with an Auth code, which the Wrapper handles and validates against Yahoo!
            // this check basically checks if that QS exists or not
            if (this.Parameters != null & this.Parameters.Count > 0)
            {
                // First step to Validate Code and get User Context
                UserInfo userInfo = await this._authClient.GetUserInfo(this.Parameters);
                UserInfo user = userInfo;
                userInfo = (UserInfo)null;


                //Below are sample Calls to the Yahoo! Api using the wrapper, they can be removed/altered
                Game leagueDtos = await this._fantasyClient.GameResourceManager.GetMeta("371", this._authClient.Auth.AccessToken);
                leagueDtos = await this._fantasyClient.GameResourceManager.GetPositionTypes("371", this._authClient.Auth.AccessToken);
                leagueDtos = await this._fantasyClient.GameResourceManager.GetRosterPositions("371", this._authClient.Auth.AccessToken);
                leagueDtos = await this._fantasyClient.GameResourceManager.GetStatCategories("371", this._authClient.Auth.AccessToken);
                leagueDtos = await this._fantasyClient.GameResourceManager.GetGameWeeks("371", this._authClient.Auth.AccessToken);

                leagueDtos = await this._fantasyClient.GameResourceManager.GetLeagues("371", new string[] { "371.l.494774" }, this._authClient.Auth.AccessToken);
                leagueDtos = await this._fantasyClient.GameResourceManager.GetPlayers("371", new string[] { "371.p.24788" }, this._authClient.Auth.AccessToken);


                var foo = await this._fantasyClient.GameCollectionsManager.GetGames(new string[] { "371" }, EndpointSubResourcesCollection.BuildResourceList(EndpointSubResources.GameWeeks, EndpointSubResources.StatCategories, EndpointSubResources.PositionTypes, EndpointSubResources.RosterPositions), this._authClient.Auth.AccessToken
                    , new GameCollectionFilters
                    {
                        IsAvailable = true,
                        Seasons = new int[] { 2017 },
                        GameCodes = new GameCode[] { GameCode.nfl },
                        GameTypes = new GameType[] { GameType.Full }
                    });

            }
            return (IActionResult)this.View((object)model);
        }

        public RedirectResult Login()
        {
            // This route will redirect to Yahoo! Auth page, where use will login/authorize app and than get redirected to Callback Url specified on App Registration
            // Also should be in AppSettings
            return new RedirectResult(this._authClient.GetLoginLinkUri());
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
