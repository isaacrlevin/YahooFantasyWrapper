using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace YahooFantasyWrapper.Models
{
    [XmlRoot(ElementName = "league", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public class League
    {
        [XmlElement(ElementName = "league_key", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string LeagueKey { get; set; }
        [XmlElement(ElementName = "league_id", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string LeagueId { get; set; }
        [XmlElement(ElementName = "name", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string Name { get; set; }
        [XmlElement(ElementName = "url", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string Url { get; set; }
        [XmlElement(ElementName = "password", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string Password { get; set; }
        [XmlElement(ElementName = "draft_status", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string DraftStatus { get; set; }
        [XmlElement(ElementName = "num_teams", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string NumTeams { get; set; }
        [XmlElement(ElementName = "edit_key", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string EditKey { get; set; }
        [XmlElement(ElementName = "weekly_deadline", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string WeeklyDeadline { get; set; }
        [XmlElement(ElementName = "league_update_timestamp", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string LeagueUpdateTimestamp { get; set; }
        [XmlElement(ElementName = "scoring_type", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string ScoringType { get; set; }
        [XmlElement(ElementName = "league_type", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string LeagueType { get; set; }
        [XmlElement(ElementName = "renew", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string Renew { get; set; }
        [XmlElement(ElementName = "renewed", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string Renewed { get; set; }
        [XmlElement(ElementName = "short_invitation_url", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string ShortInvationUrl { get; set; }
        [XmlElement(ElementName = "allow_add_to_dl_extra_pos", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public bool AllowAddToDlExtraPos { get; set; }
        [XmlElement(ElementName = "is_pro_league", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public bool IsProLeague { get; set; }
        [XmlElement(ElementName = "is_cash_league", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public bool IsCashLeague { get; set; }
        [XmlElement(ElementName = "current_week", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public int CurrentWeek { get; set; }
        [XmlElement(ElementName = "start_week", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public int StartWeek { get; set; }
        [XmlElement(ElementName = "start_date", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string StartDate { get; set; }
        [XmlElement(ElementName = "end_week", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public int EndWeek { get; set; }
        [XmlElement(ElementName = "end_date", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string EndDate { get; set; }
        [XmlElement(ElementName = "game_code", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string GameCode { get; set; }
        [XmlElement(ElementName = "season", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string Season { get; set; }

        [XmlElement(ElementName = "players", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public PlayerList PlayerList { get; set; }

        [XmlElement(ElementName = "teams", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public TeamList TeamList { get; set; }
        [XmlElement(ElementName = "settings", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public Settings Settings { get; set; }
        [XmlElement(ElementName = "standings", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public Standings Standings { get; set; }
        [XmlElement(ElementName = "scoreboard", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public Scoreboard Scoreboard { get; set; }

        [XmlElement(ElementName = "draft_results")]
        public DraftResults DraftResults { get; set; }

    }

    [XmlRoot(ElementName = "leagues", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public class LeagueList
    {
        [XmlElement(ElementName = "league", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public List<League> Leagues { get; set; }
        [XmlAttribute(AttributeName = "count")]
        public string Count { get; set; }
    }


    [XmlRoot(ElementName = "draft_result")]
    public class DraftResult
    {
        [XmlElement(ElementName = "pick")]
        public int Pick { get; set; }
        [XmlElement(ElementName = "round")]
        public int Round { get; set; }
        [XmlElement(ElementName = "team_key")]
        public string TeamKey { get; set; }
        [XmlElement(ElementName = "player_key")]
        public string PlayerKey { get; set; }
    }

    [XmlRoot(ElementName = "draft_results")]
    public class DraftResults
    {
        [XmlElement(ElementName = "draft_result")]
        public List<DraftResult> DraftResult { get; set; }
        [XmlAttribute(AttributeName = "count")]
        public string Count { get; set; }
    }

}
