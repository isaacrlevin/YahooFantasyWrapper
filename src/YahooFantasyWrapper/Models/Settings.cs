using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace YahooFantasyWrapper.Models
{
    [XmlRoot(ElementName = "settings", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public class Settings
    {
        [XmlElement(ElementName = "draft_type", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string DraftType { get; set; }
        [XmlElement(ElementName = "is_auction_draft", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string IsAuctionDraft { get; set; }
        [XmlElement(ElementName = "scoring_type", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string ScoringType { get; set; }
        [XmlElement(ElementName = "persistent_url", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string PersistentUrl { get; set; }
        [XmlElement(ElementName = "uses_playoff", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string UsesPlayoff { get; set; }
        [XmlElement(ElementName = "has_playoff_consolation_games", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string HasPlayoffConsolationGames { get; set; }
        [XmlElement(ElementName = "playoff_start_week", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string PlayoffStartWeek { get; set; }
        [XmlElement(ElementName = "uses_playoff_reseeding", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string UsesPlayoffReseeding { get; set; }
        [XmlElement(ElementName = "uses_lock_eliminated_teams", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string UsesLockEliminatedTeams { get; set; }
        [XmlElement(ElementName = "num_playoff_teams", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string NumPlayoffTeams { get; set; }
        [XmlElement(ElementName = "num_playoff_consolation_teams", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string NumPlayoffConsolationTeams { get; set; }
        [XmlElement(ElementName = "has_multiweek_championship", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string HasMultiweekChampionship { get; set; }
        [XmlElement(ElementName = "waiver_type", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string WaiverType { get; set; }
        [XmlElement(ElementName = "waiver_rule", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string WaiverRule { get; set; }
        [XmlElement(ElementName = "uses_faab", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string UsesFaab { get; set; }
        [XmlElement(ElementName = "draft_time", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string DraftTime { get; set; }
        [XmlElement(ElementName = "draft_pick_time", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string DraftPickTime { get; set; }
        [XmlElement(ElementName = "post_draft_players", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string PostDraftPlayers { get; set; }
        [XmlElement(ElementName = "max_teams", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string MaxTeams { get; set; }
        [XmlElement(ElementName = "waiver_time", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string WaiverTime { get; set; }
        [XmlElement(ElementName = "trade_end_date", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string TradeEndDate { get; set; }
        [XmlElement(ElementName = "trade_ratify_type", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string TradeRatifyType { get; set; }
        [XmlElement(ElementName = "trade_reject_time", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string TradeRejectTime { get; set; }
        [XmlElement(ElementName = "player_pool", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string PlayerPool { get; set; }
        [XmlElement(ElementName = "cant_cut_list", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string CantCutList { get; set; }
        [XmlElement(ElementName = "is_publicly_viewable", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string IsPubliclyViewable { get; set; }
        [XmlElement(ElementName = "can_trade_draft_picks", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string CanTradeDraftPicks { get; set; }
        [XmlElement(ElementName = "roster_positions", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public RosterPositions RosterPositions { get; set; }
        [XmlElement(ElementName = "stat_categories", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public StatCategories StatCategories { get; set; }
        [XmlElement(ElementName = "stat_modifiers", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public StatModifiers StatModifiers { get; set; }
        [XmlElement(ElementName = "pickem_enabled", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string PickemEnabled { get; set; }
        [XmlElement(ElementName = "uses_fractional_points", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string UsesFractionalPoints { get; set; }
        [XmlElement(ElementName = "uses_negative_points", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string UsesNegativePoints { get; set; }
    }

}
