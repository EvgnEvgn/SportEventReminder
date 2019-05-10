using System;
using System.Collections.Generic;
using System.Text;

namespace SportEventReminder.Domain
{
    public class Season : EntityBase<int>
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Team Winner { get; set; }

        public League League { get; set; }
    }
}
