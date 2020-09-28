using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Quartz.Impl;
using Quartz;
using System.Collections.Specialized;
using Quartz.Spi;

namespace WorkerScheduleService
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();   
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder()
                //.UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    NameValueCollection props = new NameValueCollection
                    {
                        { "quartz.serializer.type", "binary" },
                        { "quartz.scheduler.instanceName", "MyScheduler" },
                        { "quartz.jobStore.type", "Quartz.Simpl.RAMJobStore, Quartz" },
                        { "quartz.threadPool.threadCount", "3" }
                    };

                    //StdSchedulerFactory factory = new StdSchedulerFactory(props);
                    services.AddHostedService<Worker>();
                    services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
                    services.AddSingleton<IJobFactory, WorkerJobFactory>();
                    services.Configure<WorkerSchedulerConfiguration>(
                        hostContext.Configuration.GetSection(nameof(WorkerSchedulerConfiguration)));
                    services.AddTransient<WorkerJob>();
                    services.AddHttpClient();
                    services.AddTransient<RequestService>();
                });
    }
}
