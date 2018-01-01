using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using YahooFantasyWrapper.Infrastructure;
using YahooFantasyWrapper.Models;

namespace YahooFantasyWrapper.Client
{
    internal static class Utils
    {
        /// <summary>
        /// Gets Access Token and makes Request against Endpoint passed in
        /// </summary>
        /// <param name="endpoint">Uri of Api to Query</param>
        /// <param name="AccessToken">Items on QS/Form Data used to fulfill Api Call</param>
        /// <returns></returns>
        internal static async Task<XDocument> GetResponseData(EndPoint endpoint, string AccessToken)
        {
            RequestFactory _factory = new RequestFactory();
            var client = _factory.CreateClient(endpoint, new AuthenticationHeaderValue("Bearer", AccessToken));

            var request = _factory.CreateRequest(endpoint);

            var response = await client.GetAsync(request.RequestUri).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(result))
            {
                throw new Exception("Combination of Resource and SubResources Not Allowed, Please try altering");
            }

            return XDocument.Parse(result);
        }

        internal static async Task<List<T>> GetCollection<T>(EndPoint endPoint, string AccessToken, string lookup)
        {
            var xml = await Utils.GetResponseData(endPoint, AccessToken);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            List<XElement> xElements = xml.Descendants(YahooXml.XMLNS + lookup).ToList();
            List<T> collection = new List<T>();
            foreach (var element in xElements)
            {
                collection.Add((T)serializer.Deserialize(element.CreateReader()));
            }

            return collection;
        }

        internal static async Task<T> GetResource<T>(EndPoint endPoint, string AccessToken, string lookup)
        {
            var xml = await Utils.GetResponseData(endPoint, AccessToken);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XElement xElement = xml.Descendants(YahooXml.XMLNS + lookup).FirstOrDefault();
            var resource = (T)serializer.Deserialize(xElement.CreateReader());
            return resource;
        }
    }
}
