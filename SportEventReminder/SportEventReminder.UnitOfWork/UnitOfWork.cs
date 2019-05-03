using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SportEventReminder.EntityFramework;
using SportEventReminder.Repositories;
using SportEventReminder.Repositories.Base;
using SportEventReminder.Repositories.Interfaces;

namespace SportEventReminder.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly SportEventReminderDbContext _dbContext;
        private readonly IServiceProvider _serviceProcProvider;

        public ITeamRepository TeamRepository { get; }
        public IAreaRepository AreaRepository { get; }
        public IExternalSourceIntegrationRepository ExternalSourceIntegrationRepository { get; }

        public UnitOfWork(SportEventReminderDbContext dbContext, 
                          IServiceProvider serviceProvider, 
                          ITeamRepository teamRepository,
                          IAreaRepository areaRepository,
                          IExternalSourceIntegrationRepository externalSourceIntegrationRepository)
        {
            _dbContext = dbContext;
            _serviceProcProvider = serviceProvider;

            TeamRepository = teamRepository;
            AreaRepository = areaRepository;
            ExternalSourceIntegrationRepository = externalSourceIntegrationRepository;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
