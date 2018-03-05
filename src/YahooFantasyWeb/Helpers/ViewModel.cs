using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YahooFantasyWrapper.Models;

namespace YahooFantasyWeb
{
    [Serializable]
    public class ViewModel
    {
        public string Token { get; set; }

        public Profile Profile { get; set; }
    }
}
