using System;
using System.Collections.Generic;
using System.Text;

namespace SportEventReminder.ImportService.Contracts.FootballDataOrgContracts
{
    public class MatchResponse
    {
        public CompetitionContract Competition { get; set; }

        public List<MatchContract> Matches { get; set; }
    }
}
