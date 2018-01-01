using System;
using System.Collections.Generic;
using System.Text;

namespace YahooFantasyWrapper.Client
{
    /// <summary>
    /// Base class for Api Endpoints
    /// </summary>
    public class EndPoint
    {
        /// <summary>
        /// Base URI (service host address).
        /// </summary>
        public string BaseUri { get; set; }

        /// <summary>
        /// Resource URI (service method).
        /// </summary>
        public string Resource { get; set; }

        /// <summary>
        /// Complete URI of endpoint (base URI combined with resource URI).
        /// </summary>
        public string Uri { get { return BaseUri + Resource; } }
    }
}
