using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YahooFantasyWrapper.Client;
using YahooFantasyWrapper.Models;

namespace YahooFantasyWeb.Pages
{
    public class IndexModel : PageModel
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

        public IndexModel(IYahooAuthClient authClient, IYahooFantasyClient fantasyClient)
        {
            this._authClient = authClient;
            this._fantasyClient = fantasyClient;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            byte[] bytes = null ;
            var model = new ViewModel();

            // By default, Yahoo! sends a QS param with an Auth code, which the Wrapper handles and validates against Yahoo!
            // this check basically checks if that QS exists or not
            if ((this.Parameters != null & this.Parameters.Count > 0) || (HttpContext.Session.TryGetValue("auth", out bytes)))
            {

                if (bytes == null)
                {
                    UserInfo userInfo = await this._authClient.GetUserInfo(this.Parameters);
                    model = new ViewModel
                    {
                        Token = this._authClient.Auth.AccessToken,
                        Profile = userInfo.Profile
                    };
                    HttpContext.Session.Set("auth", model.ToBytes());
                }
                else
                {
                    model = bytes.ToViewModel();
                } 
                
                TempData["auth"] = model;
                //var leagues = await this._fantasyClient.UserResourceManager.GetUserGameLeagues(this._authClient.Auth.AccessToken, new string[] { "371" }, EndpointSubResourcesCollection.BuildResourceList(EndpointSubResources.Settings));

                //var leagueKeys = leagues.GameList.Games.First(a => a.GameKey == "371").LeagueList.Leagues.Select(a => a.LeagueKey).ToArray();


                //var leagueTeams = await this._fantasyClient.TeamsCollectionManager.GetLeagueTeams(this._authClient.Auth.AccessToken, leagueKeys, EndpointSubResourcesCollection.BuildResourceList(EndpointSubResources.Roster));



                ////Below are sample Calls to the Yahoo! Api using the wrapper, they can be removed/altered
                //Game leagueDtos = await this._fantasyClient.GameResourceManager.GetMeta("371", this._authClient.Auth.AccessToken);
                //leagueDtos = await this._fantasyClient.GameResourceManager.GetPositionTypes("371", this._authClient.Auth.AccessToken);
                //leagueDtos = await this._fantasyClient.GameResourceManager.GetRosterPositions("371", this._authClient.Auth.AccessToken);
                //leagueDtos = await this._fantasyClient.GameResourceManager.GetStatCategories("371", this._authClient.Auth.AccessToken);
                //leagueDtos = await this._fantasyClient.GameResourceManager.GetGameWeeks("371", this._authClient.Auth.AccessToken);

                //leagueDtos = await this._fantasyClient.GameResourceManager.GetLeagues("371", new string[] { "371.l.494774" }, this._authClient.Auth.AccessToken);
                //leagueDtos = await this._fantasyClient.GameResourceManager.GetPlayers("371", new string[] { "371.p.24788" }, this._authClient.Auth.AccessToken);


                //var foo = await this._fantasyClient.GameCollectionsManager.GetGames(new string[] { "371" }, EndpointSubResourcesCollection.BuildResourceList(EndpointSubResources.GameWeeks, EndpointSubResources.StatCategories, EndpointSubResources.PositionTypes, EndpointSubResources.RosterPositions), this._authClient.Auth.AccessToken
                //    , new GameCollectionFilters
                //    {
                //        IsAvailable = true,
                //        Seasons = new int[] { 2017 },
                //        GameCodes = new GameCode[] { GameCode.nfl },
                //        GameTypes = new GameType[] { GameType.Full }
                //    });
            }
            return Page();
        }

        public async Task<IActionResult> OnPostLoginAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return new RedirectResult(this._authClient.GetLoginLinkUri());
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _authClient.Auth = null;
            HttpContext.Session.Clear();
            return RedirectToPage();
        }
    }
}
