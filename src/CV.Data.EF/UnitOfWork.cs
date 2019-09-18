using CV.Core.Data;
using CV.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CV.Data.EF
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        protected readonly IServiceProvider _serviceProvider;

        protected ConcurrentDictionary<Type, object> Repositories = new ConcurrentDictionary<Type, object>();

        private readonly CVContext _dbContext;

        private IDbContextTransaction _dbContextTransaction;


        public UnitOfWork(IServiceProvider serviceProvider, CVContext dbContext)
        {
            _serviceProvider = serviceProvider;
            _dbContext = dbContext;

        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : new()
        {

            if (!Repositories.TryGetValue(typeof(IRepository<TEntity>), out var repository))
            {
                Repositories[typeof(IRepository<TEntity>)] =
                    repository = _serviceProvider.GetRequiredService<IRepository<TEntity>>();
            }

            return repository as IRepository<TEntity>;
        }

        public void BenginTran(IsolationLevel iSolationLevel = IsolationLevel.Serializable)
        {
            _dbContextTransaction = _dbContext.Database.BeginTransaction(iSolationLevel);
        }

        public void Commit()
        {
            _dbContextTransaction.Commit();
        }

        public void Dispose()
        {
            if (_dbContextTransaction != null)
                _dbContextTransaction.Dispose();
        }

        public void RollBackTran()
        {
            _dbContextTransaction.Rollback();
        }
    }
}
