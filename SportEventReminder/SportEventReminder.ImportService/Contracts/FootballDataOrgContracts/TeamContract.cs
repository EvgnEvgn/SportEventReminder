using System;
using System.Collections.Generic;
using System.Text;

namespace SportEventReminder.ImportService.Contracts.FootballDataOrgContracts
{
    public class TeamContract
    {
        public int Id { get; set; }

        public AreaContract Area { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Tag { get; set; }
    }
}
