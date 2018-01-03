using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Text;
using YahooFantasyWrapper.Client;
using System.Net.Http.Headers;

namespace YahooFantasyWrapper.Infrastructure
{
    internal static class RequestFactoryExtensions
    {
        public static HttpClient CreateClient(this IRequestFactory factory, EndPoint endpoint, AuthenticationHeaderValue auth)
        {
            var client = factory.CreateClient(auth);
            client.BaseAddress = new Uri(endpoint.BaseUri);
            return client;
        }

        internal static HttpRequestMessage CreateRequest(this IRequestFactory factory, EndPoint endpoint)
        {
            return CreateRequest(factory, endpoint, HttpMethod.Get);
        }

        internal static HttpRequestMessage CreateRequest(this IRequestFactory factory, EndPoint endpoint, HttpMethod method)
        {
            var request = factory.CreateRequest();
            request.RequestUri = new Uri(endpoint.Uri);
            request.Method = method;
            return request;
        }

        internal static HttpRequestMessage CreateRequest(this IRequestFactory factory, Uri uri, HttpMethod method)
        {
            var request = factory.CreateRequest();
            request.RequestUri = uri;
            request.Method = method;
            return request;
        }
    }
}
