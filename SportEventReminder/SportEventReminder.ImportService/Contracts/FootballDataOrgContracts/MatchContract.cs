using System;
using System.Collections.Generic;
using System.Text;

namespace SportEventReminder.ImportService.Contracts.FootballDataOrgContracts
{
    public class MatchContract
    {
        public int Id { get; set; }

        public DateTime UtcDate { get; set; }

        public string Status { get; set; }

        public TeamContract HomeTeam { get; set; }

        public TeamContract AwayTeam { get; set; }

        public CompetitionContract Competition { get; set; }
    }
}
