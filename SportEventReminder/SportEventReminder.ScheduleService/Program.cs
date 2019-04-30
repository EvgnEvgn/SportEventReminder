using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SportEventReminder.EntityFramework;
using SportEventReminder.Repositories.Base;
using SportEventReminder.Repositories.Interfaces;
using SportEventReminder.Repositories.Repositories;
using SportEventReminder.UnitOfWork;

namespace SportEventReminder.ScheduleService
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();
            serviceCollection.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //serviceCollection.AddTransient<ITeamRepository, TeamRepository>();
            
            serviceCollection.AddDbContext<SportEventReminderDbContext>(options =>
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SportEventReminderTestDb;Trusted_Connection=True;"));

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var uow = serviceProvider.GetService<IUnitOfWork>();
            var repo = uow.GetRepository<Team>();


        }
    }
}
