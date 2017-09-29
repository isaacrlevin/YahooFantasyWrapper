using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using YahooFantasyWrapper.Client;

namespace YahooFantasyWrapper.Infrastructure
{
    public static class NameValueCollectionExtensions
    {
        /// <summary>
        /// Check to make sure QS Parameters have been passed, otherwise Exception
        /// </summary>
        /// <param name="collection">QS to Parse</param>
        /// <param name="key">Key for QS Param</param>
        /// <returns></returns>
        public static string GetOrThrowUnexpectedResponse(this NameValueCollection collection, string key)
        {
            var value = collection[key];
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new UnexpectedResponseException(key);
            }
            return value;
        }
    }
}
