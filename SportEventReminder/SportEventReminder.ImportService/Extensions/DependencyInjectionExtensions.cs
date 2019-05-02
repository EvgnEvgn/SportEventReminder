using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SportEventReminder.UnitOfWork.Extensions;

namespace SportEventReminder.ImportService.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddImportServices(this IServiceCollection serviceCollection,
            IConfiguration cfg)
        {
            return serviceCollection
                .AddDataAccessLayer(cfg);
        }
    }
}
