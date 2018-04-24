using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace YahooFantasyWrapper.Infrastructure
{
    internal static class YahooXml
    {
        /// <summary>
        /// Xml Namespace for Yahoo Fantasy Xml Returned
        /// </summary>
        internal static XNamespace XMLNS = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng";

        internal static XNamespace XMLNS_V1_NoWWW = "http://yahooapis.com/v1/base.rng";

        internal static XNamespace XMLNS_V1 = "http://yahooapis.com/v1/base.rng";
    }
}
