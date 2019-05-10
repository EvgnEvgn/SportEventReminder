using System;
namespace SportEventReminder.DTO
{
    public class SeasonDto : BaseDto
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public TeamDto Winner { get; set; }
    }
}
