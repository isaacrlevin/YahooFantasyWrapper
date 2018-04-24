using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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
            return await await ResilientCall(async () =>
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
            });
        }

        /// <summary>
        /// Generic Handler to Retrieve Collection for Api
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endPoint">EndPoint requested</param>
        /// <param name="AccessToken"></param>
        /// <param name="lookup">Collection Type to Retrieve</param>
        /// <returns></returns>
        internal static async Task<List<T>> GetCollection<T>(EndPoint endPoint, string AccessToken, string lookup)
        {

            return await await ResilientCall(async () =>
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
            });
        }

        /// <summary>
        /// Generic Handler to Retrieve Resource for Api
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endPoint">EndPoint requested</param>
        /// <param name="AccessToken"></param>
        /// <param name="lookup">Resource Type to Retrieve</param>
        /// <returns></returns>
        internal static async Task<T> GetResource<T>(EndPoint endPoint, string AccessToken, string lookup)
        {
            return await await ResilientCall(async () =>
            {
                var xml = await Utils.GetResponseData(endPoint, AccessToken);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                XElement xElement = xml.Descendants(YahooXml.XMLNS + lookup).FirstOrDefault();
                if (xElement == null && IsError(xml))                
                    throw new InvalidOperationException(GetErrorMessage(xml));
                if (xElement == null)
                    throw new InvalidOperationException($"Invalid XML returned. {xml}");

                var resource = (T)serializer.Deserialize(xElement.CreateReader());
                return resource;
            });
        }

        private static string GetErrorMessage(XDocument xml)
        {            
            var result = 
                from e in xml.Root.Elements()
                where e.Name.LocalName == "description"
                select e.Value;                
            
            return result.FirstOrDefault() ?? "Unknown XML";
        }

        async static Task<T> ResilientCall<T>(Func<T> block)
        {
            int currentRetry = 0;
            TimeSpan delay = TimeSpan.FromSeconds(2);

            for (; ; )
            {
                try
                {
                    return block();
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Operation Exception");

                    currentRetry++;

                    // Check if the exception thrown was a transient exception
                    // based on the logic in the error detection strategy.
                    // Determine whether to retry the operation, as well as how
                    // long to wait, based on the retry strategy.
                    if (currentRetry > 3 || !IsTransient(ex))
                    {
                        // If this isn't a transient error or we shouldn't retry, 
                        // rethrow the exception.
                        throw;
                    }
                }

                // Wait to retry the operation.
                // Consider calculating an exponential delay here and
                // using a strategy best suited for the operation and fault.
                await Task.Delay(delay);
            }
        }

        private static bool IsTransient(Exception ex)
        {
            var webException = ex as WebException;
            if (webException != null)
            {
                // If the web exception contains one of the following status values
                // it might be transient.
                return new[] {WebExceptionStatus.ConnectionClosed,
                  WebExceptionStatus.Timeout,
                  WebExceptionStatus.RequestCanceled }.
                        Contains(webException.Status);
            }

            // Additional exception checking logic goes here.
            return false;
        }


        private static bool IsError(XDocument xml)
        {
            return string.Equals(xml.Root.Name.LocalName, "error", StringComparison.OrdinalIgnoreCase);
        }

    }
}
