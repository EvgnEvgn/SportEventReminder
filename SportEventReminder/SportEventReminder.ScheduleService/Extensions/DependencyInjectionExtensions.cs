using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportEventReminder.ImportService.Extensions;

namespace SportEventReminder.ScheduleService.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection serviceCollection,
            IConfiguration cfg)
        {
            return serviceCollection
                .AddSingleton<ScheduleService>()
                .AddImportServices(cfg);
        }
    }
}
