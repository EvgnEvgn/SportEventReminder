﻿using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using SportEventReminder.Repositories.Interfaces;
using SportEventReminder.Repositories.Repositories;
using SportEventReminder.UnitOfWork;
using Topshelf;
using Microsoft.Extensions.Configuration;
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

            var serviceCollection = new ServiceCollection();
            serviceCollection.ConfigureServices(configuration);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var serviceRunner = HostFactory.Run(cfg =>
            {
                cfg.Service(x => serviceProvider.GetService<ScheduleService>());
            });

            var exitCode = (int)Convert.ChangeType(serviceRunner, serviceRunner.GetTypeCode());
            Environment.ExitCode = exitCode;
        }
    }
}
