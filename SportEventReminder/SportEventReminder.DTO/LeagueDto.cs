using System.Collections.Generic;
using SportEventReminder.Common.Enums;

namespace SportEventReminder.DTO
{
    public class LeagueDto : BaseDto
    {
        public string Name { get; set; }

        public AreaDto Area { get; set; }

        public SeasonDto CurrentSeason { get; set; }

        public List<SeasonDto> Seasons { get; set; }

        public LeagueLevel LeagueLevel { get; set; }
    }
}
