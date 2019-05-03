using Flurl.Http.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SportEventReminder.ImportService.Configuration;
using SportEventReminder.ImportService.Interfaces;
using SportEventReminder.ImportService.Services;
using SportEventReminder.UnitOfWork.Extensions;

namespace SportEventReminder.ImportService.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddImportServices(this IServiceCollection serviceCollection,
            IConfiguration cfg)
        {
            return serviceCollection
                .Configure<FootballImportServiceConfiguration>(
                    cfg.GetSection(nameof(FootballImportServiceConfiguration)))
                .AddScoped(container =>
                    container.GetService<IOptionsSnapshot<FootballImportServiceConfiguration>>().Value)
                .AddDataAccessLayer(cfg)
                .AddSingleton<IFlurlClientFactory, PerHostFlurlClientFactory>()
                .AddScoped<FootballImportService>()
                .AddScoped<IFootballImporter, FootballDataOrgImporter>();

        }
    }
}
