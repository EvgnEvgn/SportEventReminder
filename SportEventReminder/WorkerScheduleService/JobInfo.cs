using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerScheduleService
{
    public class JobInfo
    {
        public string Id { get;set; }

        public string Url { get; set; }

        public string CronTemplate { get; set; }
    }
}
