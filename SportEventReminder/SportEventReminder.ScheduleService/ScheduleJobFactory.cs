using System;
using Quartz;
using Quartz.Spi;

namespace SportEventReminder.ScheduleService
{
    public class ScheduleJobFactory : IJobFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ScheduleJobFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return (IJob)_serviceProvider.GetService(bundle.JobDetail.JobType);
        }

        public void ReturnJob(IJob job)
        {
            var disposable = job as IDisposable;
            disposable?.Dispose();
        }
    }
}
