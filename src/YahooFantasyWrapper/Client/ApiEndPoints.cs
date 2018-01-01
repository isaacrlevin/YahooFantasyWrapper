using System.Linq;
using YahooFantasyWrapper.Models;
//using System.Net;
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

        #region Game

        public static EndPoint GameMetaDataEndPoint(string gameKey)
        {
            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/game/{gameKey}/metadata"
            };
        }

        public static EndPoint GameLeaguesEndPoint(string gameKey, string[] leagueKeys)
        {
            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/game/{gameKey}/leagues;league_keys={string.Join(",", leagueKeys)}"
            };
        }

        public static EndPoint GamePlayersEndPoint(string gameKey, string[] playerKeys)
        {
            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/game/{gameKey}/players;player_keys={string.Join(",", playerKeys)}"
            };
        }

        public static EndPoint GameGameWeeksEndPoint(string gameKey)
        {
            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/game/{gameKey}/game_weeks"
            };
        }

        public static EndPoint GameStatCategoriesEndPoint(string gameKey)
        {
            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/game/{gameKey}/stat_categories"
            };
        }

        public static EndPoint GamePositionTypesEndPoint(string gameKey)
        {
            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/game/{gameKey}/position_types"
            };
        }

        public static EndPoint GameRosterPositionsEndPoint(string gameKey)
        {
            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/game/{gameKey}/roster_positions"
            };
        }

        public static EndPoint GamesEndPoint(string[] gameKeys, EndpointSubResourcesCollection subresources, bool? isAvailable, int[] seasons = null, GameCode[] gameCodes = null, GameType[] gameTypes = null)
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

            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/games{games}{available}{years}{gameCodeString}{gType}{subs}"
            };
        }

        public static EndPoint GamesUserEndPoint(string[] gameKeys = null, EndpointSubResourcesCollection subresources = null, bool? isAvailable = null, int[] seasons = null, GameCode[] gameCodes = null, GameType[] gameTypes = null)
        {
            string games = "";
            if (gameKeys != null && gameKeys.Length > 0)
            {
                games = $";game_keys={ string.Join(",", gameKeys)}";
            }

            string subs = "";
            if (subresources != null && subresources.Resources.Count > 0)
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

            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/users{LoginString}/games{games}{available}{years}{gameCodeString}{gType}{subs}"
            };
        }
        
        
        
        #endregion

        #region User

        public static EndPoint UserGamesEndPoint
        {
            get
            {
                return new EndPoint
                {
                    BaseUri = BaseApiUrl,
                    Resource = $"/users{LoginString}/games"
                };
            }
        }

        public static EndPoint UserGameLeaguesEndPoint(string[] gameKeys = null, EndpointSubResourcesCollection subresources = null)
        {
            string games = "";
            if (gameKeys != null && gameKeys.Length > 0)
            {
                games = $";game_keys={ string.Join(",", gameKeys)}";
            }

            string subs = "";
            if (subresources != null && subresources.Resources.Count > 0)
            {
                subs = $";out={ string.Join(",", subresources.Resources.Select(a => a.ToFriendlyString()))}";

            }

            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/users{LoginString}/games{games}/leagues{subs}"
            };
        }

        public static EndPoint UserGamesTeamsEndPoint(string[] gameKeys, EndpointSubResourcesCollection subresources)
        {
            string games = "";
            if (gameKeys.Length > 0)
            {
                games = $";game_keys={ string.Join(",", gameKeys)}";
            }
            string subs = "";
            if (subresources != null && subresources.Resources.Count > 0)
            {
                subs = $";out={ string.Join(",", subresources.Resources.Select(a => a.ToFriendlyString()))}";
            }
            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/users{LoginString}/games{games}/teams{subs}"
            };
        }

        #endregion

        public static EndPoint LeagueTeamsEndPoint(string[] leagueKeys, EndpointSubResourcesCollection subresources)
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
            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/leagues{leagues}/teams{subs}"
            };

        }



        #region Transaction

        public static EndPoint TransactionMetaEndpoint(string transactionKey)
        {
            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/transaction/{transactionKey}/players"
            };
        }

        #endregion
    }
}
