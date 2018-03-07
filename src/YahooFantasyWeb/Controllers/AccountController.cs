using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using YahooFantasyWrapper.Client;

namespace YahooFantasyWeb.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {

        private readonly IYahooAuthClient _authClient;
        private readonly IYahooFantasyClient _fantasyClient;

        public AccountController(IYahooAuthClient authClient, IYahooFantasyClient fantasyClient)
        {
            this._authClient = authClient;
            this._fantasyClient = fantasyClient;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            _authClient.ClearAuth();
            return LocalRedirect(Url.GetLocalUrl(returnUrl));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            return new RedirectResult(this._authClient.GetLoginLinkUri());
        }
    }
}