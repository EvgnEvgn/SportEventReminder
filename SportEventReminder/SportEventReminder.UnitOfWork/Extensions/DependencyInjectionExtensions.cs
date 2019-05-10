using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportEventReminder.EntityFramework;
using SportEventReminder.Repositories.Interfaces;
using SportEventReminder.Repositories.Repositories;

namespace SportEventReminder.UnitOfWork.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection serviceCollection, IConfiguration cfg)
        {
            return serviceCollection
                .AddDbContext<SportEventReminderDbContext>(options =>
                    options.UseSqlServer(cfg.GetDefaultConnectionString()))
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<ITeamRepository, TeamRepository>()
                .AddScoped<IAreaRepository, AreaRepository>()
                .AddScoped<IExternalSourceIntegrationRepository, ExternalSourceIntegrationRepository>()
                .AddScoped<ILeagueRepository, LeagueRepository>();
        }

        public static string GetDefaultConnectionString(this IConfiguration configuration)
        {
            return configuration.GetConnectionString("DefaultConnection");
        }
    }
}
