using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Text;
using YahooFantasyWrapper.Client;
using System.Net.Http.Headers;

namespace YahooFantasyWrapper.Infrastructure
{
    public static class RequestFactoryExtensions
    {
        public static HttpClient CreateClient(this IRequestFactory factory, Endpoint endpoint, AuthenticationHeaderValue auth)
        {
            var client = factory.CreateClient(auth);
            client.BaseAddress = new Uri(endpoint.BaseUri);
            return client;
        }

        public static HttpRequestMessage CreateRequest(this IRequestFactory factory, Endpoint endpoint)
        {
            return CreateRequest(factory, endpoint, HttpMethod.Get);
        }

        public static HttpRequestMessage CreateRequest(this IRequestFactory factory, Endpoint endpoint, HttpMethod method)
        {
            var request = factory.CreateRequest();
            request.RequestUri = new Uri(endpoint.Uri);
            request.Method = method;
            return request;
        }

        public static HttpRequestMessage CreateRequest(this IRequestFactory factory, Uri uri, HttpMethod method)
        {
            var request = factory.CreateRequest();
            request.RequestUri = uri;
            request.Method = method;
            return request;
        }
    }
}
