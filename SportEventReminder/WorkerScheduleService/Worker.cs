using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting.WindowsServices;
using Quartz.Spi;
using Quartz;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Quartz.Impl;

namespace WorkerScheduleService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private IScheduler _scheduler;
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly WorkerSchedulerConfiguration _configuration;
        private readonly IJobFactory _jobFactory;


        public Worker(ILogger<Worker> logger, IOptions<WorkerSchedulerConfiguration> options, ISchedulerFactory schedulerFactory, IJobFactory jobFactory)
        {
           _logger = logger;
           _schedulerFactory = schedulerFactory;
            _configuration = options.Value;
            _jobFactory = jobFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
           _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            NameValueCollection props = new NameValueCollection
            {
                { "quartz.serializer.type", "binary" },
                { "quartz.scheduler.instanceName", "MyScheduler" },
                { "quartz.jobStore.type", "Quartz.Simpl.RAMJobStore, Quartz" },
                { "quartz.threadPool.threadCount", "3" }
            };
            _scheduler = await _schedulerFactory.GetScheduler(stoppingToken);
            //_scheduler = await new StdSchedulerFactory(props).GetScheduler();
            _scheduler.JobFactory = _jobFactory;
            await _scheduler.Start(stoppingToken);

            var jobs = GetJobsAndTriggers(_configuration);
            await _scheduler.ScheduleJobs(jobs, replace: true, cancellationToken: stoppingToken);
          
            
            var current_jobs = await _scheduler.GetCurrentlyExecutingJobs(stoppingToken);
            _logger.LogError($"{current_jobs.Count}");
            _logger.LogError($"{_scheduler.IsStarted}");

            //await Task.Delay(1000, stoppingToken);   
        }

        private static IReadOnlyDictionary<IJobDetail, IReadOnlyCollection<ITrigger>> GetJobsAndTriggers(WorkerSchedulerConfiguration cfg)
        {
            var dictionary = new Dictionary<IJobDetail, IReadOnlyCollection<ITrigger>>();
            foreach(var job in cfg.Jobs)
            {
                JobDataMap data = new JobDataMap();
                data["apiUrl"] = cfg.ApiUrl;
                data["requestUrl"] = job.Url;


                IJobDetail jobDetail = JobBuilder
                                    .Create<WorkerJob>()
                                    .WithIdentity($"Job{job.Id}")
                                    .SetJobData(data)
                                    .Build();

                ITrigger everydayTrigger = TriggerBuilder
                                    .Create()
                                    .WithIdentity($"TriggerForJob{job.Id}")
                                    // fires 
                                    .WithCronSchedule(job.CronTemplate)
                                    .StartNow()
                                    .Build();

                dictionary.Add(jobDetail, new Collection<ITrigger>(new[] { everydayTrigger }));
            }
            
            return dictionary;
        }
    }
}
