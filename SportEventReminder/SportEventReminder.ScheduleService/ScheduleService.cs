using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using SportEventReminder.Domain;
using SportEventReminder.ScheduleService.Jobs;
using Topshelf;

namespace SportEventReminder.ScheduleService
{
    public class ScheduleService : ServiceControl
    {
        private readonly ILogger _logger;

        private readonly IScheduler _scheduler;

        private const int importFootballDataIntervalInHours = 24;

        public ScheduleService(ILogger<ScheduleService> logger, IJobFactory jobFactory)
        {
            _logger = logger;
            NameValueCollection props = new NameValueCollection
            {
                { "quartz.serializer.type", "binary" },
                { "quartz.scheduler.instanceName", "MyScheduler" },
                { "quartz.jobStore.type", "Quartz.Simpl.RAMJobStore, Quartz" },
                { "quartz.threadPool.threadCount", "3" }
            };

            StdSchedulerFactory factory = new StdSchedulerFactory(props);
            _scheduler = factory.GetScheduler().ConfigureAwait(false).GetAwaiter().GetResult();
            _scheduler.JobFactory = jobFactory;
        }


        public bool Start(HostControl hostControl)
        {
            _logger.LogWarning("SchedulerService started.");

            _scheduler.Start().ConfigureAwait(false).GetAwaiter().GetResult();

            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.CreateForAsync<FootballImportJob>()
                .WithIdentity("job1", "group1")
                .Build();

            // Trigger the job to run now, and then repeat every 10 seconds
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInHours(importFootballDataIntervalInHours)
                    .RepeatForever())
                .Build();

            _scheduler.ScheduleJob(job, trigger).ConfigureAwait(false).GetAwaiter().GetResult();

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _scheduler.Shutdown().ConfigureAwait(false).GetAwaiter().GetResult();
            return true;
        }
    }
}
