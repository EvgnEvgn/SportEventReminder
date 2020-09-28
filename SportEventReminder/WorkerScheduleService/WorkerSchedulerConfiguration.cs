using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerScheduleService
{
    public class WorkerSchedulerConfiguration
    {
        public string ApiUrl { get; set; }

        public JobInfo[] Jobs { get; set; }
    }
}
