using System.Threading.Tasks;
using System.Net;
using YahooFantasyWrapper.Models;
using System.Reflection;
using System.Net.Http.Headers;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Text;
using YahooFantasyWrapper.Configuration;
using YahooFantasyWrapper.Infrastructure;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Linq;

namespace YahooFantasyWrapper.Client
{
    public class YahooFantasyClient : IYahooFantasyClient
    {
        private readonly IRequestFactory _factory;

        public YahooFantasyClient(IRequestFactory factory)
        {
            _factory = factory;
        }

        #region Users
        /// <summary>
        /// Get User Info from Yahoo Fantasy Scope
        /// </summary>
        /// <param name="AccessToken">Access Token from Auth Api</param>
        /// <returns>User Object</returns>
        public async Task<User> GetUser(string AccessToken)
        {
            var xml = await GetResponseData(ApiEndpoints.UserEndPoint, AccessToken);
            XmlSerializer serializer = new XmlSerializer(typeof(User));
            XElement userElement = xml.Descendants(YahooXml.XMLNS + "user").FirstOrDefault();
            var user = (User)serializer.Deserialize(userElement.CreateReader());
            return user;
        }

        #endregion

        #region Games
        /// <summary>
        /// Get Games for Logged-In User
        /// https://fantasysports.yahooapis.com/fantasy/v2/users;use_login=1/games;game_keys={gameKeys};out={subresources}
        /// </summary>
        /// <param name="gameKeys">List of GameKeys to Query</param>
        /// <param name="subresources">Sub Resources Specified to Retrieve with Api</param>
        /// <param name="AccessToken">Access Token from Auth Api</param>
        /// <returns>List of Games</returns>
        public async Task<IList<Game>> GetUserGames(string[] gameKeys, EndpointSubResourcesCollection subresources, string AccessToken)
        {
            var xml = await GetResponseData(ApiEndpoints.UserGamesEndPoint(gameKeys, subresources, true), AccessToken);
            XmlSerializer serializer = new XmlSerializer(typeof(Game));
            List<XElement> gameElements = xml.Descendants(YahooXml.XMLNS + "game").ToList();
            IList<Game> games = new List<Game>();
            foreach (var gameElement in gameElements)
            {
                games.Add((Game)serializer.Deserialize(gameElement.CreateReader()));
            }
            return games;
        }

        /// <summary>
        /// Get List of Leagues for Logged-In User
        /// https://fantasysports.yahooapis.com/fantasy/v2/users{LoginString}/games{games}/leagues{subs}
        /// </summary>
        /// <param name="leagueKeys">List of League Keys for Query</param>
        /// <param name="subresources">Sub Resources Specified to Retrieve with Api</param>
        /// <param name="AccessToken">Access Token from Auth Api</param>
        /// <returns>List of Leagues</returns>
        public async Task<IList<League>> GetLeagues(string[] leagueKeys, EndpointSubResourcesCollection subresources, string AccessToken)
        {
            var xml = await GetResponseData(ApiEndpoints.UserGameLeaguesWithKeyEndPoint(leagueKeys, subresources), AccessToken);
            XmlSerializer serializer = new XmlSerializer(typeof(League));
            List<XElement> leagueElements = xml.Descendants(YahooXml.XMLNS + "league").ToList();
            IList<League> leagues = new List<League>();
            foreach (var leagueElement in leagueElements)
            {
                leagues.Add((League)serializer.Deserialize(leagueElement.CreateReader()));
            }
            return leagues;
        }

        /// <summary>
        /// Get List of Teams for Leagues specified
        /// https://fantasysports.yahooapis.com/fantasy/v2/leagues{leagues}/teams{subs}
        /// </summary>
        /// <param name="leagueKeys">List of League Keys for Query</param>
        /// <param name="subresources">Sub Resources Specified to Retrieve with Api</param>
        /// <param name="AccessToken">Access Token from Auth Api</param>
        /// <returns>List of Leagues</returns>
        public async Task<IList<League>> GetLeagueTeams(string[] leagueKeys, EndpointSubResourcesCollection subresources, string AccessToken)
        {
            var xml = await GetResponseData(ApiEndpoints.LeagueTeamsEndPoint(leagueKeys, subresources), AccessToken);
            XmlSerializer serializer = new XmlSerializer(typeof(League));
            List<XElement> leagueElements = xml.Descendants(YahooXml.XMLNS + "league").ToList();
            IList<League> leagues = new List<League>();
            foreach (var leagueElement in leagueElements)
            {
                leagues.Add((League)serializer.Deserialize(leagueElement.CreateReader()));
            }
            return leagues;
        }
        #endregion


        /// <summary>
        /// Gets Access Token and makes Request against Endpoint passed in
        /// </summary>
        /// <param name="endpoint">Uri of Api to Query</param>
        /// <param name="AccessToken">Items on QS/Form Data used to fulfill Api Call</param>
        /// <returns></returns>
        private async Task<XDocument> GetResponseData(Endpoint endpoint, string AccessToken)
        {
            var client = _factory.CreateClient(endpoint, new AuthenticationHeaderValue("Bearer", AccessToken));

            var request = _factory.CreateRequest(endpoint);

            var response = await client.GetAsync(request.RequestUri);
            var result = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(result))
            {
                throw new Exception("Combination of Resource and SubResources Not Allowed, Please try altering");
            }

            return XDocument.Parse(result);
        }
    }
}