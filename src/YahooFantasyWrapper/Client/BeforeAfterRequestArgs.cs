using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using YahooFantasyWrapper.Configuration;

namespace YahooFantasyWrapper.Client
{
    public class BeforeAfterRequestArgs
    {
        /// <summary>
        /// Client instance.
        /// </summary>
        public HttpClient Client { get; set; }

        /// <summary>
        /// Request instance.
        /// </summary>
        public HttpRequestMessage Request { get; set; }

        /// <summary>
        /// Response instance.
        /// </summary>
        public string Response { get; set; }

        /// <summary>
        /// Values received from service.
        /// </summary>
        public NameValueCollection Parameters { get; set; }

        /// <summary>
        /// Client configuration.
        /// </summary>
        public YahooConfiguration Configuration { get; set; }
    }
}
