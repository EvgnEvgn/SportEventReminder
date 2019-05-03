using System;
using System.Collections.Generic;

namespace SportEventReminder.ImportService.Configuration
{
    public class FootballImportServiceConfiguration
    {
        public string FootballDataOrgApiUrl { get; set; }

        public string FootballDataOrgApiKey { get; set; }

        public AvailableLeague[] FootballDataOrgAvailableLeagues { get; set; }
    }

    public class AvailableLeague
    {
        public string LeagueName { get; set; }

        public string LeagueCountryName { get; set; }
    }
}
