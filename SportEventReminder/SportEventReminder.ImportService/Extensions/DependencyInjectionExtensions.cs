using AutoMapper;
using Flurl.Http.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SportEventReminder.Common.Configuration;
using SportEventReminder.ImportService.Interfaces;
using SportEventReminder.ImportService.Services;
using SportEventReminder.Managers.AreaManager;
using SportEventReminder.Managers.LeagueManager;
using SportEventReminder.Managers.MatchManager;
using SportEventReminder.Managers.TeamManager;
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
                .AddScoped<IFootballImportService, FootballImportService>()
                .AddScoped<IFootballImporter, FootballDataOrgImporter>()
                .AddScoped<ILeagueManager, LeagueManager>()
                .AddScoped<IAreaManager, AreaManager>()
                .AddScoped<ITeamManager, TeamManager>()
                .AddScoped<IMatchManager, MatchManager>()
                .AddAutoMapper();

        }
    }
}
