using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace YahooFantasyWrapper.Models
{
    public enum SortOrder {  Asc = 0, Desc = 1}
    [XmlRoot(ElementName = "stat", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public class Stat
    {
        [XmlElement(ElementName = "stat_id", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string StatId { get; set; }
        [XmlElement(ElementName = "name", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string Name { get; set; }
        [XmlElement(ElementName = "display_name", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string DisplayName { get; set; }
        [XmlElement(ElementName = "sort_order", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public SortOrder SortOrder { get; set; }
        [XmlElement(ElementName = "position_types", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public PositionTypes PositionTypes { get; set; }
        [XmlElement(ElementName = "position_type", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public string PositionType { get; set; }
        [XmlElement(ElementName = "value", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public double Value { get; set; }
    }

    [XmlRoot(ElementName = "stats", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public class Stats
    {
        [XmlElement(ElementName = "stat", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public List<Stat> Stat { get; set; }
    }

    [XmlRoot(ElementName = "stat_categories", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public class StatCategories
    {
        [XmlElement(ElementName = "stats", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public Stats Stats { get; set; }
    }

    [XmlRoot(ElementName = "stat_modifiers", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public class StatModifiers
    {
        [XmlElement(ElementName = "stats", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public Stats Stats { get; set; }
    }
}
