using System;
using System.Collections.Generic;
using System.Text;
using SportEventReminder.Common.Enums;
using SportEventReminder.Domain;

namespace SportEventReminder.Domain
{
    public class Match : EntityBase<int>
    {
        public League League { get; set; }

        public DateTime StartDate { get; set; }

        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }

        public MatchStatusEnum Status { get; set; }
    }
}
