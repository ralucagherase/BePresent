using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BePresent.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BePresent.Repository.Implementation
{
    public class UnitOfWork<TContext> :  IUnitOfWork
        where TContext : DbContext
    {

        private Dictionary<Type, object> _repositories;
        public UnitOfWork(TContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public TContext Context { get; }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);

            if (!_repositories.ContainsKey(type))
            {
                _repositories[type] = new Repository<TEntity>(Context);
            }

            return (IRepository<TEntity>)_repositories[type];
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }

    }
}
