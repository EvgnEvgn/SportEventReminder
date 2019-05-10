using System;
using System.Collections.Generic;
using System.Text;

namespace SportEventReminder.DTO
{
    public class AreaDto : BaseDto
    {
        public string Name { get; set; }

        public string ParentArea { get; set; }
    }
}
