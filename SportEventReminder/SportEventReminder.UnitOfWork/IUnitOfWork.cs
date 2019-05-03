using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SportEventReminder.Repositories;
using SportEventReminder.Repositories.Base;
using SportEventReminder.Repositories.Interfaces;

namespace SportEventReminder.UnitOfWork
{
    public interface IUnitOfWork
    {
        int Commit();
        Task<int> CommitAsync();
        Task<int> CommitAsync(CancellationToken cancellationToken);

        ITeamRepository TeamRepository { get; }
        IAreaRepository AreaRepository { get; }
        IExternalSourceIntegrationRepository ExternalSourceIntegrationRepository { get; }
    }
}
