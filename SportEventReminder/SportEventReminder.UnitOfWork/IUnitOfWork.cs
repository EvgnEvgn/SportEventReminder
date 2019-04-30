using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SportEventReminder.Repositories;
using SportEventReminder.Repositories.Base;

namespace SportEventReminder.UnitOfWork
{
    public interface IUnitOfWork
    {
        int Commit();
        Task<int> CommitAsync();
        Task<int> CommitAsync(CancellationToken cancellationToken);

        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}
