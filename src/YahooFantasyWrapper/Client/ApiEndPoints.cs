using System.Linq;
using YahooFantasyWrapper.Models;
//using System.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace YahooFantasyWrapper.Client
{
    internal static class ApiEndpoints
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

        internal static EndPoint GameEndPoint(string gameKey)
        {
            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/game/{gameKey}"
            };
        }

        internal static EndPoint GameEndPoint(string gameKey, EndpointSubResources resource)
        {
            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/game/{gameKey}/{resource.ToFriendlyString()}"
            };
        }

        internal static EndPoint GameLeaguesEndPoint(string gameKey, string[] leagueKeys)
        {
            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/game/{gameKey}/leagues;league_keys={string.Join(",", leagueKeys)}"
            };
        }

        internal static EndPoint GamePlayersEndPoint(string gameKey, string[] playerKeys)
        {
            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/game/{gameKey}/players;player_keys={string.Join(",", playerKeys)}"
            };
        }

        internal static EndPoint GamesEndPoint(string[] gameKeys, EndpointSubResourcesCollection subresources = null, GameCollectionFilters filters = null)
        {
            string games = "";
            if (gameKeys.Length > 0)
            {
                games = $";game_keys={ string.Join(",", gameKeys)}";
            }

            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/games{games}{BuildGameFiltersList(filters)}{BuildSubResourcesList(subresources)}"
            };
        }

        internal static EndPoint GamesUserEndPoint(string[] gameKeys = null, EndpointSubResourcesCollection subresources = null, GameCollectionFilters filters = null)
        {
            string games = "";
            if (gameKeys != null && gameKeys.Length > 0)
            {
                games = $";game_keys={ string.Join(",", gameKeys)}";
            }

            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/users{LoginString}/games{games}{BuildGameFiltersList(filters)}{BuildSubResourcesList(subresources)}"
            };
        }



        #endregion

        #region User

        internal static EndPoint UserGamesEndPoint
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

        internal static EndPoint UserGameLeaguesEndPoint(string[] gameKeys = null, EndpointSubResourcesCollection subresources = null)
        {
            string games = "";
            if (gameKeys != null && gameKeys.Length > 0)
            {
                games = $";game_keys={ string.Join(",", gameKeys)}";
            }

            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/users{LoginString}/games{games}/leagues{BuildSubResourcesList(subresources)}"
            };
        }

        internal static EndPoint UserGamesTeamsEndPoint(string[] gameKeys, EndpointSubResourcesCollection subresources)
        {
            string games = "";
            if (gameKeys.Length > 0)
            {
                games = $";game_keys={ string.Join(",", gameKeys)}";
            }

            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/users{LoginString}/games{games}/teams{BuildSubResourcesList(subresources)}"
            };
        }

        #endregion

        #region League

        internal static EndPoint LeagueEndPoint(string leagueKey, EndpointSubResources resource, int?[] weeks = null)
        {
            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/league/{leagueKey}/{resource.ToFriendlyString()}{BuildWeekList(weeks)}"
            };
        }

        internal static EndPoint LeaguesEndPoint(string[] leagueKeys, EndpointSubResourcesCollection subresources = null)
        {
            string leagues = "";
            if (leagueKeys.Length > 0)
            {
                leagues = $";league_keys={ string.Join(",", leagueKeys)}";
            }

            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/leagues{leagues}{BuildSubResourcesList(subresources)}"
            };
        }

        internal static EndPoint LeagueTeamsEndPoint(string[] leagueKeys, EndpointSubResourcesCollection subresources)
        {
            string leagues = "";
            if (leagueKeys.Length > 0)
            {
                leagues = $";league_keys={ string.Join(",", leagueKeys)}";
            }

            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/leagues{leagues}/teams{BuildSubResourcesList(subresources)}"
            };

        }
        #endregion

        #region Player

        internal static EndPoint PlayerOwnershipEndPoint(string[] playerKeys, string leagueKey)
        {
            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/league/{leagueKey}/players;player_keys={string.Join(",", playerKeys)}/ownership"
            };
        }

        internal static EndPoint PlayerEndPoint(string playerKey, EndpointSubResources resource)
        {
            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/player/{playerKey}/{resource.ToFriendlyString()}"
            };
        }

        internal static EndPoint PlayersEndPoint(string[] playerKeys, EndpointSubResourcesCollection subresources = null)
        {
            string players = "";
            if (playerKeys.Length > 0)
            {
                players = $";player_keys={ string.Join(",", playerKeys)}";
            }

            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/players{players}{BuildSubResourcesList(subresources)}"
            };
        }

        internal static EndPoint PlayersLeagueEndPoint(string[] leagueKeys, EndpointSubResourcesCollection subresources = null, PlayerCollectionFilters filters = null)
        {
            string leagues = "";
            if (leagueKeys.Length > 0)
            {
                leagues = $";league_keys={ string.Join(",", leagueKeys)}";
            }

            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/leagues{leagues}/players{BuildSubResourcesList(subresources)}{BuildPlayersFiltersList(filters)}"
            };
        }

        internal static EndPoint PlayersTeamEndPoint(string[] teamKeys, EndpointSubResourcesCollection subresources = null, PlayerCollectionFilters filters = null)
        {
            string teams = "";
            if (teamKeys.Length > 0)
            {
                teams = $";team_keys={ string.Join(",", teamKeys)}";
            }

            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/teams{teams}/players{BuildSubResourcesList(subresources)}{BuildPlayersFiltersList(filters)}"
            };
        }
        #endregion

        #region Roster
        internal static EndPoint RosterEndPoint(string teamKey, int? week = null, DateTime? date = null)
        {
            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/team/{teamKey}/roster/{BuildWeekList(new int?[] { week })}{BuildDate(date)}"
            };

        }

        #endregion

        #region Team

        internal static EndPoint TeamEndPoint(string teamKey, EndpointSubResources resource)
        {
            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/team/{teamKey}/{resource.ToFriendlyString()}"
            };
        }
        internal static EndPoint TeamsEndPoint(string[] teamKeys, EndpointSubResourcesCollection subresources = null)
        {
            string teams = "";
            if (teamKeys.Length > 0)
            {
                teams = $";team_keys={ string.Join(",", teamKeys)}";
            }

            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/teams{teams}{BuildSubResourcesList(subresources)}"
            };
        }

        internal static EndPoint TeamsLeagueEndPoint(string[] leagueKeys, EndpointSubResourcesCollection subresources = null)
        {
            string leagues = "";
            if (leagueKeys.Length > 0)
            {
                leagues = $";league_keys={ string.Join(",", leagueKeys)}";
            }

            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/leagues{leagues}/teams{BuildSubResourcesList(subresources)}"
            };
        }

        internal static EndPoint TeamsUserGamesEndPoint(string[] gameKeys, EndpointSubResourcesCollection subresources = null)
        {
            string games = "";
            if (gameKeys.Length > 0)
            {
                games = $";gameKeys={ string.Join(",", gameKeys)}";
            }

            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/users{LoginString}/games{games}{BuildSubResourcesList(subresources)}"
            };
        }

        #endregion

        #region Transaction

        internal static EndPoint TransactionEndpoint(string transactionKey, EndpointSubResources resource)
        {
            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/transaction/{transactionKey}/{resource.ToFriendlyString()}"
            };
        }

        internal static EndPoint TransactionsEndPoint(string[] transactionKeys, EndpointSubResourcesCollection subresources = null)
        {
            string transactions = "";
            if (transactionKeys.Length > 0)
            {
                transactions = $";transaction_keys={ string.Join(",", transactionKeys)}";
            }

            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/transactions{transactions}{BuildSubResourcesList(subresources)}"
            };
        }

        internal static EndPoint TransactionsLeagueEndPoint(string[] leagueKeys, EndpointSubResourcesCollection subresources = null)
        {
            string leagues = "";
            if (leagueKeys.Length > 0)
            {
                leagues = $";league_keys={ string.Join(",", leagueKeys)}";
            }

            return new EndPoint
            {
                BaseUri = BaseApiUrl,
                Resource = $"/leagues{leagues}{BuildSubResourcesList(subresources)}"
            };
        }

        #endregion

        private static string BuildSubResourcesList(EndpointSubResourcesCollection subresources)
        {
            string subs = "";
            if (subresources != null && subresources.Resources.Count > 0)
            {
                subs = $";out={ string.Join(",", subresources.Resources.Select(a => a.ToFriendlyString()))}";

            }
            return subs;
        }

        private static string BuildGameFiltersList(GameCollectionFilters filters)
        {
            string available = "";
            if (filters.IsAvailable != null)
            {
                available = $";is_available={(Convert.ToInt32(filters.IsAvailable.Value))}";
            }

            string years = "";
            if (filters.Seasons != null && filters.Seasons.Length > 0)
            {
                years = $";seasons={string.Join(",", filters.Seasons)}";
            }

            string gameCodeString = "";
            if (filters.GameCodes != null && filters.GameCodes.Length > 0)
            {
                gameCodeString = $";game_codes={string.Join(",", filters.GameCodes.Select(a => Enum.GetName(typeof(GameCode), a)))}";
            }

            string gType = "";
            if (filters.GameTypes != null && filters.GameTypes.Length > 0)
            {
                gType = $";game_types={ string.Join(",", filters.GameTypes.Select(a => a.ToFriendlyString()))}";

            }
            return $"{available}{years}{gameCodeString}{gType}";
        }

        private static string BuildPlayersFiltersList(PlayerCollectionFilters filters)
        {

            return $"";
        }

        private static string BuildWeekList(int?[] weeks)
        {
            string weekString = "";
            if (weeks != null && weeks.Length > 0)
            {
                weekString = $";week={ string.Join(",", weeks.Select(a => a.ToString()))}";
            }
            return $"{weekString}";
        }

        private static string BuildDate(DateTime? date)
        {
            string dt = "";
            if (date != null)
            {
                dt = $";date={ date.Value.ToString("yyyy-M-dd") }";
            }

            return dt;
        }
    }
}
