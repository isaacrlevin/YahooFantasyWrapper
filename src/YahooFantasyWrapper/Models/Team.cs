using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace YahooFantasyWrapper.Models
{
    [XmlRoot(ElementName = "team_logo")]
    public class TeamLogo
    {
        [XmlElement(ElementName = "size")]
        public string Size { get; set; }
        [XmlElement(ElementName = "url")]
        public string Url { get; set; }
    }

    [XmlRoot(ElementName = "team_logos")]
    public class TeamLogos
    {
        [XmlElement(ElementName = "team_logo")]
        public TeamLogo TeamLogo { get; set; }
        [XmlElement(ElementName = "size", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string Size { get; set; }
        [XmlElement(ElementName = "url", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string Url { get; set; }
    }

    [XmlRoot(ElementName = "roster_adds")]
    public class RosterAdds
    {
        [XmlElement(ElementName = "coverage_type")]
        public string CoverageType { get; set; }
        [XmlElement(ElementName = "coverage_value")]
        public string CoverageValue { get; set; }
        [XmlElement(ElementName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "team")]
    public class Team
    {
        [XmlElement(ElementName = "team_key")]
        public string TeamKey { get; set; }
        [XmlElement(ElementName = "team_id")]
        public string TeamId { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "is_owned_by_current_login")]
        public string IsOwnedByCurrentLogin { get; set; }
        [XmlElement(ElementName = "url")]
        public string Url { get; set; }
        [XmlElement(ElementName = "team_logos")]
        public TeamLogos TeamLogos { get; set; }
        [XmlElement(ElementName = "waiver_priority")]
        public string WaiverPriority { get; set; }
        [XmlElement(ElementName = "faab_balance")]
        public string FaabBalance { get; set; }
        [XmlElement(ElementName = "number_of_moves")]
        public string NumberOfMoves { get; set; }
        [XmlElement(ElementName = "number_of_trades")]
        public string NumberOfTrades { get; set; }
        [XmlElement(ElementName = "roster_adds")]
        public RosterAdds RosterAdds { get; set; }
        [XmlElement(ElementName = "league_scoring_type")]
        public string LeagueScoringType { get; set; }
        [XmlElement(ElementName = "has_draft_grade")]
        public string HasDraftGrade { get; set; }
        [XmlElement(ElementName = "draft_grade")]
        public string DraftGrade { get; set; }
        [XmlElement(ElementName = "draft_recap_url")]
        public string DraftRecapUrl { get; set; }
        [XmlElement(ElementName = "managers")]
        public Managers Managers { get; set; }

        [XmlElement(ElementName = "roster")]
        public Roster Roster { get; set; }
    }

    [XmlRoot(ElementName = "teams")]
    public class Teams
    {
        [XmlElement(ElementName = "team")]
        public List<Team> Team { get; set; }
        [XmlAttribute(AttributeName = "count")]
        public string Count { get; set; }
    }


    [XmlRoot(ElementName = "roster", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public class Roster
    {
        [XmlElement(ElementName = "coverage_type", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string CoverageType { get; set; }
        [XmlElement(ElementName = "week", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string Week { get; set; }
        [XmlElement(ElementName = "is_editable", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string IsEditable { get; set; }
        [XmlElement(ElementName = "players", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public Players Players { get; set; }
    }
}
