using System;
using System.Collections.Generic;
using System.Text;

namespace SportEventReminder.ImportService.Contracts.FootballDataOrgContracts
{
    public class ErrorContract
    {
        public string Message { get; set; }

        public int ErrorCode { get; set; }
    }
}
