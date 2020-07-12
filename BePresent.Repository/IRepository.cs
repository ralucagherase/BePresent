using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BePresent.Resources.Constants;
using Microsoft.EntityFrameworkCore.Query;

namespace BePresent.Repository.Interface
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate = null,
                               Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                               Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                               bool disableTracking = true);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null,
                                          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                          Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                          bool disableTracking = true,
                                          CancellationToken cancellationToken = default(CancellationToken));

        IPaginate<TEntity> GetList(Expression<Func<TEntity, bool>> predicate = null,
                                   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                   Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                   int page = 1,
                                   int size = 20,
                                   bool disableTracking = true);

        Task<IPaginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null,
                                                  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                                  int page = 1,
                                                  int size = 20,
                                                  bool disableTracking = true,
                                                  CancellationToken cancellationToken = default(CancellationToken));

        IPaginate<TResult> GetList<TResult>(Expression<Func<TEntity, TResult>> selector,
                                            Expression<Func<TEntity, bool>> predicate = null,
                                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                            int page = 1,
                                            int size = 20,
                                            bool disableTracking = true)
            where TResult : class;

        Task<IPaginate<TResult>> GetListAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
                                                       Expression<Func<TEntity, bool>> predicate = null,
                                                       Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                       Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                                       int page = 1,
                                                       int size = 20,
                                                       bool disableTracking = true,
                                                       CancellationToken cancellationToken = default(CancellationToken))
            where TResult : class;

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true);

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null,
                                               Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                               Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                               bool disableTracking = true,
                                               CancellationToken cancellationToken = default(CancellationToken));
        Task<IEnumerable<TEntity>> GetAllByBatchesAsync(Expression<Func<TEntity, bool>> predicate = null,
                                       Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                       Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                       bool disableTracking = true,
                                       int batchSize = PaginationConstants.PageSize,
                                       CancellationToken cancellationToken = default(CancellationToken));

        IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector,
                                             Expression<Func<TEntity, bool>> predicate = null,
                                             Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                             Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                             bool disableTracking = true)
            where TResult : class;

        Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
                                             Expression<Func<TEntity, bool>> predicate = null,
                                             Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                             Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                             bool disableTracking = true,
                                             CancellationToken cancellationToken = default(CancellationToken))
            where TResult : class;

        Task<IEnumerable<TResult>> GetAllByBatchesAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
                                       Expression<Func<TEntity, bool>> predicate = null,
                                       Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                       Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                       bool disableTracking = true,
                                       int batchSize = PaginationConstants.PageSize,
                                       CancellationToken cancellationToken = default(CancellationToken))
           where TResult : class;

        void Add(TEntity entity);
        void Add(params TEntity[] entities);
        void Add(IEnumerable<TEntity> entities);

        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
        Task AddAsync(params TEntity[] entities);
        Task AddAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));

        void Delete(TEntity entity);
        void Delete(int id);
        void Delete(params TEntity[] entities);

        void Update(TEntity entity);
        void Update(params TEntity[] entities);
        void Update(IEnumerable<TEntity> entities);
    }
}
