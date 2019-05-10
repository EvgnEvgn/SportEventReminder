using System;

namespace SportEventReminder.ImportService.Contracts.FootballDataOrgContracts
{
    /// <summary>
    /// Лига (турнир, соревнование)
    /// </summary>
    public class CompetitionContract
    {
        public int Id { get; set; }
         
        public AreaContract Area { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string EmblemUrl { get; set; }

        public string Plan { get; set; }

        public SeasonContract CurrentSeason { get; set; }

        public SeasonContract[] Seasons { get; set; }

        public DateTime? LastUpdated { get; set; }

    }

    public class SeasonContract
    {
        public int Id { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public TeamContract Winner { get; set; }
    }
}
