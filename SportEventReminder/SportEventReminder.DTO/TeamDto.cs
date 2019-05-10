using System;
using System.Collections.Generic;
using System.Text;

namespace SportEventReminder.DTO
{
    public class TeamDto : BaseDto
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Tag { get; set; }

        public AreaDto Area { get; set; }
    }
}
