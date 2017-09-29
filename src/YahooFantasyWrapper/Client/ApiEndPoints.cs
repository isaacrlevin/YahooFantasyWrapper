using System.Linq;
using YahooFantasyWrapper.Models;
using System.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace YahooFantasyWrapper.Client
{
    public static class ApiEndpoints
    {
        #region Const
        /// <summary>
        /// Api Url for Yahoo Fantasy Api :https://fantasysports.yahooapis.com/fantasy/v2
        /// </summary>
        private const string BaseApiUrl = "https://fantasysports.yahooapis.com/fantasy/v2";

        /// <summary>
        /// QS Parameter to specify to use the authenticated users scope
        /// </summary>
        private const string LoginString = ";use_login=1";

        #endregion

     

        #region User

        public static Endpoint UserEndPoint
        {
            get
            {
                return new Endpoint
                {
                    BaseUri = BaseApiUrl,
                    Resource = $"/users{LoginString}"
                };
            }
        }

        public static Endpoint UserGamesEndPoint(string[] gameKeys, EndpointSubResourcesCollection subresources, bool? isAvailable, int[] seasons = null, GameCode[] gameCodes = null, GameType[] gameTypes = null)
        {
            string games = "";
            if (gameKeys.Length > 0)
            {
                games = $";game_keys={ string.Join(",", gameKeys)}";
            }

            string subs = "";
            if (subresources.Resources.Count > 0)
            {
                subs = $";out={ string.Join(",", subresources.Resources.Select(a => a.ToFriendlyString()))}";

            }

            string available = "";
            if (isAvailable != null)
            {
                available = $";is_available={(Convert.ToInt32(isAvailable.Value))}";
            }

            string years = "";
            if (seasons != null && seasons.Length > 0)
            {
                years = $";seasons={string.Join(",", seasons)}";
            }

            string gameCodeString = "";
            if (gameCodes != null && gameCodes.Length > 0)
            {
                gameCodeString = $";game_codes={string.Join(",", gameCodes.Select(a => Enum.GetName(typeof(GameCode), a)))}";
            }

            string gType = "";
            if (gameTypes != null && gameTypes.Length > 0)
            {
                gType = $";game_types={ string.Join(",", gameTypes.Select(a => a.ToFriendlyString()))}";

            }

            return new Endpoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/users{LoginString}/games{games}{available}{years}{gameCodeString}{gType}{subs}"
            };
        }

        public static Endpoint UserGameLeaguesWithKeyEndPoint(string[] gameKeys, EndpointSubResourcesCollection subresources)
        {
            string games = "";
            if (gameKeys.Length > 0)
            {
                games = $";game_keys={ string.Join(",", gameKeys)}";
            }

            string subs = "";
            if (subresources.Resources.Count > 0)
            {
                subs = $";out={ string.Join(",", subresources.Resources.Select(a => a.ToFriendlyString()))}";

            }

            return new Endpoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/users{LoginString}/games{games}/leagues{subs}"
            };
        }

        public static Endpoint UserGameTeamsWithKeyEndPoint(string[] gameKeys, EndpointSubResources[] subresources)
        {
            string games = "";
            if (gameKeys.Length > 0)
            {
                games = $";game_keys={ string.Join(",", gameKeys)}";
            }
            string subs = "";
            if (subresources.Length > 0)
            {
                subs = $";out={ string.Join(",", subresources.Select(a => a.ToFriendlyString()))}";
            }
            return new Endpoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/users{LoginString}/games{games}/teams{subs}"
            };
        }

        public static Endpoint UserTeamsEndPoint(EndpointSubResources[] subresources)
        {
            string subs = "";
            if (subresources.Length > 0)
            {
                subs = $";out={ string.Join(",", subresources.Select(a => a.ToFriendlyString()))}";

            }
            return new Endpoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/users{LoginString}/teams{subs}"
            };
        }

        #endregion

        public static Endpoint LeagueTeamsEndPoint(string[] leagueKeys, EndpointSubResourcesCollection subresources)
        {
            string leagues = "";
            if (leagueKeys.Length > 0)
            {
                leagues = $";league_keys={ string.Join(",", leagueKeys)}";
            }

            string subs = "";
            if (subresources.Resources.Count > 0)
            {
                subs = $";out={ string.Join(",", subresources.Resources.Select(a => a.ToFriendlyString()))}";

            }
            return new Endpoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/leagues{leagues}/teams{subs}"
            };

        }



        #region Transaction

        public static Endpoint TransactionMetaEndpoint(string transactionKey)
        {
            return new Endpoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/transaction/{transactionKey}/players"
            };
        }

        #endregion
    }
}
