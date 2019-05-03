using System;
using System.Collections.Generic;
using System.Text;

namespace SportEventReminder.ImportService.Contracts.FootballDataOrgContracts
{
    public class AreaContract
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentAreaId { get; set; }

        public string ParentArea { get; set; }
    }
}
