using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YahooFantasyWrapper.Models;

namespace YahooFantasyWrapper.Web.Models
{
    public class UserModel
    {
        public string AccessToken { get; set; }

        public UserInfo UserInfo { get; set; }
    }

    public class PostModel
    {
        public string AccessToken { get; set; }

        public string Key { get; set; }
    }
}
