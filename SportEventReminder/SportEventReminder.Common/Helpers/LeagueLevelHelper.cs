using System;
using System.Collections.Generic;
using System.Text;
using SportEventReminder.Common.Enums;

namespace SportEventReminder.Common.Helpers
{
    public static class LeagueLevelHelper
    {
        public static LeagueLevel FromString(string leagueLevelStr, ExternalSourceEnum source)
        {
            switch (source)
            {
                case ExternalSourceEnum.FootballDataOrg:
                    switch (leagueLevelStr)
                    {
                        case "TIER_ONE":
                            return LeagueLevel.TierOne;

                        case "TIER_TWO":
                            return LeagueLevel.TierTwo;

                        case "TIER_THREE":
                            return LeagueLevel.TierThree;

                        case "TIER_FOUR":
                            return LeagueLevel.TierFour;

                        default:
                            return LeagueLevel.TierFour;
                    }
                default:
                    return LeagueLevel.TierFour;
            }
        }
    }
}
