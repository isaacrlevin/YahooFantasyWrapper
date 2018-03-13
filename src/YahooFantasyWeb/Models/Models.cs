using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YahooFantasyWrapper.Models;

namespace YahooFantasyWeb.Models
{
    public class InteractiveModel
    {
        public IEnumerable<League> Leagues { get; set; }

        public IEnumerable<Game> Games { get; set; }
    }
}
