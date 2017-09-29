using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Headers;

namespace YahooFantasyWrapper.Infrastructure
{
    /// <summary>
    /// Intended for REST client/request creation.
    /// </summary>
    public interface IRequestFactory
    {
        /// <summary>
        /// Returns new REST client instance.
        /// </summary>
        HttpClient CreateClient(AuthenticationHeaderValue auth = null);

        /// <summary>
        /// Returns new REST request instance.
        /// </summary>
        HttpRequestMessage CreateRequest();
    }

    public class RequestFactory: IRequestFactory
    {
        /// <summary>
        /// Returns new REST client instance.
        /// </summary>
       public HttpClient CreateClient(AuthenticationHeaderValue auth = null) {
            return new HttpClient() {
                DefaultRequestHeaders = { Authorization = auth }
            };
        }

        /// <summary>
        /// Returns new REST request instance.
        /// </summary>
      public  HttpRequestMessage CreateRequest() {
            return new HttpRequestMessage();
        }
    }
}
