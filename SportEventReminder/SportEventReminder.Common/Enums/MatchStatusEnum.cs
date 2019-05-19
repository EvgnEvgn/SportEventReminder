using System;
using System.Collections.Generic;
using System.Text;

namespace SportEventReminder.Common.Enums
{
    public enum MatchStatusEnum
    {
        Unknown = 0, 

        Scheduled = 1, 

        Canceled = 2, 

        Postponed = 3, 

        Suspended = 4, 

        InPlay = 5,

        Paused = 6,

        Finished = 7,

        Awarded = 8
    }
}
