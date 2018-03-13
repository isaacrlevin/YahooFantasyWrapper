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
    public class AccountController : Controller
    {
        private readonly IYahooAuthClient _authClient;
        private readonly IYahooFantasyClient _fantasyClient;

        public AccountController(IYahooAuthClient authClient, IYahooFantasyClient fantasyClient)
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

        [HttpGet("[action]")]
        public string Login()
        {
            return this._authClient.GetLoginLinkUri();
        }

        [HttpGet("[action]")]
        public async Task<UserModel> GetAuth(string code)
        {
            var authModel = new UserModel();
            if ((this.Parameters != null & this.Parameters.Count > 0) || this._authClient.UserInfo != null)
            {

                if (this._authClient.UserInfo == null)
                {
                    this._authClient.UserInfo = await this._authClient.GetUserInfo(this.Parameters);

                    authModel.AccessToken = _authClient.Auth.AccessToken;
                    authModel.UserInfo = _authClient.UserInfo;
                }
                else
                {
                    authModel.AccessToken = _authClient.Auth.AccessToken;
                    authModel.UserInfo = _authClient.UserInfo;
                }
            }
            return authModel;
        }
    }
}
