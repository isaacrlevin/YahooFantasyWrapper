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
using Microsoft.AspNetCore.Mvc.Rendering;
using YahooFantasyWrapper.Client;
using YahooFantasyWrapper.Models;

namespace YahooFantasyWeb.Pages
{
    public class InteractiveModel : PageModel
    {

        private readonly IYahooAuthClient _authClient;
        private readonly IYahooFantasyClient _fantasyClient;

        [BindProperty]
        public string Game { get; set; }

        public List<SelectListItem> Games { get; set; }

        private NameValueCollection Parameters
        {
            get
            {
                return HttpUtility.ParseQueryString(Request.QueryString.Value);
            }
        }

        public InteractiveModel(IYahooAuthClient authClient, IYahooFantasyClient fantasyClient)
        {
            this._authClient = authClient;
            this._fantasyClient = fantasyClient;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await this._fantasyClient.UserResourceManager.GetUser(_authClient.Auth.AccessToken);
            Games = user.GameList.Games
                .Where(a=> a.Type == "full")
                .OrderBy(a=> a.Season)
                .Select(a => new SelectListItem { Value = a.GameId, Text = (a.Season + " - " + a.Name) })
                .ToList();
           
            return Page();
        }

        public async Task<IActionResult> OnPostListLeaguesAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

          
            return Page();
        }
    }
}
