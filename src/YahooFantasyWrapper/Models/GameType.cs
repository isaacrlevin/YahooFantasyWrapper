using System;
using System.Collections.Generic;
using System.Text;

namespace YahooFantasyWrapper.Models
{
    public enum GameType
    {
        Full,
        PickemTeam,
        PickemGroup,
        PickemTeamList
    }
    public static class GameTypeExtensions
    {
        public static string ToFriendlyString(this GameType me)
        {
            switch (me)
            {
                case GameType.Full:
                    return "full";
                case GameType.PickemGroup:
                    return "pickem-group";
                case GameType.PickemTeam:
                    return "pickem-team";
                case GameType.PickemTeamList:
                    return "pickem-team-list";
                default:
                    return "";
            }
        }
    }
}
