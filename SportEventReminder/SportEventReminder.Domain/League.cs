using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SportEventReminder.Common.Enums;

namespace SportEventReminder.Domain
{
    public class League : EntityBase<int>
    {
        public string Name { get; set; }

        public LeagueLevel LeagueLevel { get; set; }

        [NotMapped]
        public Season CurrentSeason { get; set; }

        public List<Season> Seasons { get; set; }

        public Area Area { get; set; }
    }
}
