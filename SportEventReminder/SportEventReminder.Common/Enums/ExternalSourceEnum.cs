using System;
using System.Collections.Generic;
using System.Text;

namespace SportEventReminder.Common.Enums
{
    public enum ExternalSourceEnum
    {
        Unknown = 0,
        /// <summary>
        /// Football data api (https://www.football-data.org)
        /// </summary>

        FootballDataOrg = 1,

        /// <summary>
        /// Football data api (https://www.api-football.com/)
        /// </summary>
        ApiFootballCom = 2
    }
}
