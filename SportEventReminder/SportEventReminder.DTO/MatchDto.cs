using System;
using System.Collections.Generic;
using System.Text;
using SportEventReminder.Common.Enums;

namespace SportEventReminder.DTO
{
    public class MatchDto : BaseDto
    {
        public LeagueDto League { get; set; }

        public DateTime StartDate { get; set; }

        public MatchStatusEnum Status { get; set; }

        public TeamDto HomeTeam { get; set; }

        public TeamDto AwayTeam { get; set; }
    }
}
