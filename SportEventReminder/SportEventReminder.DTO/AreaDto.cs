using System;
using System.Collections.Generic;
using System.Text;

namespace SportEventReminder.DTO
{
    public class AreaDto
    {
        public int ExternalId { get; set; }

        public string Name { get; set; }

        public string ParentArea { get; set; }
    }
}
