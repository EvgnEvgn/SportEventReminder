﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SportEventReminder.EntityFramework;
using SportEventReminder.Repositories;
using SportEventReminder.Repositories.Base;

namespace SportEventReminder.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly SportEventReminderDbContext _dbContext;
        private readonly IServiceProvider _serviceProcProvider;

        public UnitOfWork(SportEventReminderDbContext dbContext, IServiceProvider serviceProvider)
        {
            _dbContext = dbContext;
            _serviceProcProvider = serviceProvider;
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

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return _serviceProcProvider.GetService<IGenericRepository<TEntity>>();
        }
    }
}
