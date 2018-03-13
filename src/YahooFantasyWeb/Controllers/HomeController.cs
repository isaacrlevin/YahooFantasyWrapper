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
    public class HomeController : Controller
    {
        private readonly IYahooAuthClient _authClient;
        private readonly IYahooFantasyClient _fantasyClient;

        public HomeController(IYahooAuthClient authClient, IYahooFantasyClient fantasyClient)
        {
            this._authClient = authClient;
            this._fantasyClient = fantasyClient;
        }

        private NameValueCollection Parameters
        {
            get
            {
                return HttpUtility.ParseQueryString(Request.QueryString.Value);
            }
        }
        public async Task<IActionResult> Index()
        {
            // By default, Yahoo! sends a QS param with an Auth code, which the Wrapper handles and validates against Yahoo!
            // this check basically checks if that QS exists or not
            if ((this.Parameters != null & this.Parameters.Count > 0) || this._authClient.UserInfo != null)
            {

                if (this._authClient.UserInfo == null)
                {
                    this._authClient.UserInfo = await this._authClient.GetUserInfo(this.Parameters);
                }
            }
            return View();
        }
    }
}