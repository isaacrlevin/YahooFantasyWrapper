using System;
using System.Collections.Generic;
using System.Text;
using YahooFantasyWrapper.Models;

namespace YahooFantasyWrapper.Client
{
    /// <summary>
    /// Filter Object for Game Collection
    /// </summary>
    public class GameCollectionFilters
    {
        public bool? IsAvailable { get; set; }
        public int[] Seasons { get; set; }
        public GameCode[] GameCodes { get; set; }
        public GameType[] GameTypes { get; set; }
    }

    /// <summary>
    /// Filter Object for Player Collection
    /// </summary>
    public class PlayerCollectionFilters
    {
        public string[] Positions { get; set; }
        public string[] Statuses { get; set; }
        public string Search { get; set; }
        public string Sort { get; set; }
        public string SortType { get; set; }
        public string SortSeason { get; set; }
        public string SortWeek { get; set; }
        public int? Start { get; set; }
        public int? Count { get; set; }
    }
}
