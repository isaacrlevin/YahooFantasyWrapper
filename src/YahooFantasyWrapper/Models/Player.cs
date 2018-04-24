using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace YahooFantasyWrapper.Models
{
    [XmlRoot(ElementName = "name", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public class Name
    {
        [XmlElement(ElementName = "full", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string Full { get; set; }
        [XmlElement(ElementName = "first", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string First { get; set; }
        [XmlElement(ElementName = "last", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string Last { get; set; }
        [XmlElement(ElementName = "ascii_first", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string AsciiFirstName { get; set; }
        [XmlElement(ElementName = "ascii_last", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string AsciiLastName { get; set; }
    }

    [XmlRoot(ElementName = "bye_weeks", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public class ByeWeeks
    {
        [XmlElement(ElementName = "week", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public List<string> Week { get; set; }
    }

    [XmlRoot(ElementName = "headshot", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public class Headshot
    {
        [XmlElement(ElementName = "url", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string Url { get; set; }
        [XmlElement(ElementName = "size", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string Size { get; set; }
    }

    [XmlRoot(ElementName = "eligible_positions", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public class EligiblePositions
    {
        [XmlElement(ElementName = "position", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public List<string> Position { get; set; }
    }

    [XmlRoot(ElementName = "player", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public class Player
    {
        [XmlElement(ElementName = "player_key", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string PlayerKey { get; set; }
        [XmlElement(ElementName = "player_id", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string PlayerId { get; set; }
        [XmlElement(ElementName = "name", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public Name Name { get; set; }
        [XmlElement(ElementName = "editorial_player_key", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string EditorialPlayerKey { get; set; }
        [XmlElement(ElementName = "editorial_team_key", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string EditorialTeamKey { get; set; }
        [XmlElement(ElementName = "editorial_team_full_name", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string EditorialTeamFullName { get; set; }
        [XmlElement(ElementName = "editorial_team_abbr", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string EditorialTeamAbbr { get; set; }
        [XmlElement(ElementName = "bye_weeks", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public ByeWeeks ByeWeeks { get; set; }
        [XmlElement(ElementName = "uniform_number", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string UniformNumber { get; set; }
        [XmlElement(ElementName = "display_position", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string DisplayPosition { get; set; }
        [XmlElement(ElementName = "headshot", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public Headshot Headshot { get; set; }
        [XmlElement(ElementName = "image_url", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string ImageUrl { get; set; }
        [XmlElement(ElementName = "is_undroppable", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string IsUndroppable { get; set; }
        [XmlElement(ElementName = "position_type", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string PositionType { get; set; }
        [XmlElement(ElementName = "eligible_positions", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public EligiblePositions EligiblePositions { get; set; }
        [XmlElement(ElementName = "status", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string Status { get; set; }
        [XmlElement(ElementName = "status_full", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string StatusFull { get; set; }
        [XmlElement(ElementName = "injury_note", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string InjuryNote { get; set; }
        [XmlElement(ElementName = "has_player_notes", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string HasPlayerNotes { get; set; }
        [XmlElement(ElementName = "transaction_data")]
        public TransactionData TransactionData { get; set; }
        [XmlElement(ElementName = "selected_position")]
        public SelectedPosition SelectedPosition { get; set; }
        [XmlElement(ElementName = "player_stats", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public PlayerStats PlayerStats { get; set; }

    }

    [XmlRoot(ElementName = "player_stats", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public class PlayerStats
    {
        [XmlElement(ElementName = "coverage_type", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string CoverageType { get; set; }
        [XmlElement(ElementName = "season", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string Season { get; set; }
        [XmlElement(ElementName = "stats", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public Stats Stats { get; set; }
    }

    [XmlRoot(ElementName = "players", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public class PlayerList
    {
        [XmlElement(ElementName = "player", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public List<Player> Players { get; set; }
        [XmlAttribute(AttributeName = "count")]
        public string Count { get; set; }
    }


}
