using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace YahooFantasyWrapper.Client
{
    /// <summary>
    /// Subresrources handler class
    /// </summary>
    public class EndpointSubResourcesCollection
    {
        /// <summary>
        /// List of chosen subresources
        /// </summary>
        public IList<EndpointSubResources> Resources { get; set; }

        /// <summary>
        /// Builds list of subresrources to pass onto Api
        /// </summary>
        /// <param name="resources">subresources for api</param>
        /// <returns></returns>
        public static EndpointSubResourcesCollection BuildResourceList(params EndpointSubResources[] resources)
        {
            var collection = new EndpointSubResourcesCollection
            {
                Resources = resources.ToList()
            };
            return collection;
        }
    }

    public enum EndpointSubResources
    {
        MetaData, // "metadata"
        GameWeeks,// "game_weeks"
        PositionTypes,//  "position_types"
        RosterPositions,//  "roster_positions"
        StatCategories,// "stat_categories"



        DraftResults,// "draftresults"
        Players,// "players"
        Settings,// "settings"
        Standings,// "standings"
        Scoreboard,// "scoreboard"
        Teams,// "teams"
        Transactions,// "transactions"

        Stats,// "stats"
        PercentOwned,// "percent_owned"
        DraftAnalysis,// "draft_analysis"

        Roster,// "roster"
        Matchups,// "matchups"

        Ownership,// "ownership"

        Leagues// "leagues"
    }

    public static class EndpointSubResourcesExtensions
    {
        /// <summary>
        /// Passes Enumeration and maps to friendly string for api
        /// </summary>
        /// <param name="resource">resoure to map to friendly name</param>
        /// <returns></returns>
        public static string ToFriendlyString(this EndpointSubResources resource)
        {
            switch (resource)
            {
                case EndpointSubResources.MetaData:
                    return "metadata";
                case EndpointSubResources.GameWeeks:
                    return "game_weeks";
                case EndpointSubResources.PositionTypes:
                    return "position_types";
                case EndpointSubResources.StatCategories:
                    return "stat_categories";
                case EndpointSubResources.DraftAnalysis:
                    return "draft_analysis";
                case EndpointSubResources.DraftResults:
                    return "draftresults";
                case EndpointSubResources.Players:
                    return "players";
                case EndpointSubResources.Settings:
                    return "settings";
                case EndpointSubResources.Standings:
                    return "standings";
                case EndpointSubResources.Scoreboard:
                    return "scoreboard";
                case EndpointSubResources.Teams:
                    return "teams";
                case EndpointSubResources.Transactions:
                    return "transactions";
                case EndpointSubResources.Stats:
                    return "stats";
                case EndpointSubResources.PercentOwned:
                    return "percent_owned";
                case EndpointSubResources.Roster:
                    return "roster";
                case EndpointSubResources.Matchups:
                    return "matchups";
                case EndpointSubResources.Ownership:
                    return "ownership";
                case EndpointSubResources.Leagues:
                    return "leagues";
                case EndpointSubResources.RosterPositions:
                    return "roster_positions"; 
                default:
                    return "";
            }

        }

        /// <summary>
        /// Check if List of SubResources is null or empty
        /// </summary>
        /// <param name="subresources">List of SubResources</param>
        /// <returns>if it is empty or not</returns>
        public static bool IsNotEmpty(this EndpointSubResourcesCollection subresources)
        {
            return subresources != null && subresources.Resources.Count > 0;
        }
    }
}
