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
            // By default, Yahoo! sends a QS param with an Auth code, which the Wrapper handles and validates against Yahoo!
            // this check basically checks if that QS exists or not
            if ((this.Parameters != null & this.Parameters.Count > 0) || this._authClient.UserInfo != null)
            {

                if (this._authClient.UserInfo == null)
                {
                    this._authClient.UserInfo = await this._authClient.GetUserInfo(this.Parameters);
                }

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
    }
}
