using System;
using System.Collections.Generic;
using System.Text;

namespace SportEventReminder.Common.Configuration
{
    public class FootballImportServiceConfiguration
    {
        public string FootballDataOrgApiUrl { get; set; }

        public string FootballDataOrgApiKey { get; set; }

        public AvailableLeague[] FootballDataOrgAvailableLeagues { get; set; }
    }
}
