using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using SportEventReminder.Repositories.Interfaces;
using SportEventReminder.Repositories.Repositories;
using SportEventReminder.UnitOfWork;
using Topshelf;
using Microsoft.Extensions.Configuration;
using Serilog;
using SportEventReminder.ImportService.Interfaces;
using SportEventReminder.ImportService.Services;
using SportEventReminder.ScheduleService.Extensions;
using Topshelf.HostConfigurators;

namespace SportEventReminder.ScheduleService
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appSettings.json");
            IConfiguration configuration = configurationBuilder.Build();

            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("application.log")
                .CreateLogger();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(cfg => cfg.AddSerilog(logger));
            serviceCollection.ConfigureServices(configuration);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var serviceRunner = HostFactory.Run(cfg =>
            {
                cfg.Service(x => serviceProvider.GetService<ScheduleService>());
                cfg.UseSerilog(logger);
            });

            var exitCode = (int)Convert.ChangeType(serviceRunner, serviceRunner.GetTypeCode());
            Environment.ExitCode = exitCode;
        }
    }
}
