using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BePresent.Repository.Implementation.Paging;
using BePresent.Repository.Interface;
using BePresent.Resources.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace BePresent.Repository.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity) => _dbSet.Add(entity);

        public void Add(params TEntity[] entities) => _dbSet.AddRange(entities);

        public void Add(IEnumerable<TEntity> entities) => _dbSet.AddRange(entities);

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }

        public void Delete(params TEntity[] entities) => _dbSet.RemoveRange(entities);

        public void Delete(TEntity entity) => _dbSet.Remove(entity);

        public IPaginate<TEntity> GetList(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            int page = 1, int size = 20, bool disableTracking = true)
        {
            IQueryable<TEntity> query = _dbSet;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return orderBy != null
                ? orderBy(query).ToPaginate(page, size)
                : query.ToPaginate(page, size);
        }

        public IPaginate<TResult> GetList<TResult>(Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            int page = 0, int size = 20, bool disableTracking = true) where TResult : class
        {

            IQueryable<TEntity> query = _dbSet;
            if (disableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);

            return orderBy != null
                ? orderBy(query).Select(selector).ToPaginate(page, size)
                : query.Select(selector).ToPaginate(page, size);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true)
        {
            IQueryable<TEntity> query = _dbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return orderBy != null
                ? orderBy(query).FirstOrDefault()
                : query.FirstOrDefault();
        }

        public void Update(TEntity entity) => _dbSet.Update(entity);

        public void Update(params TEntity[] entities) => _dbSet.UpdateRange(entities);

        public void Update(IEnumerable<TEntity> entities) => _dbSet.UpdateRange(entities);

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true)
        {
            IQueryable<TEntity> query = _dbSet;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return orderBy != null
                ? orderBy(query)
                : query;
        }

        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true) where TResult : class
        {
            IQueryable<TEntity> query = _dbSet;
            if (disableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);

            return orderBy != null
                ? orderBy(query).Select(selector)
                : query.Select(selector);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null,
                                                       Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                       Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                                       bool disableTracking = true,
                                                       CancellationToken cancellationToken = default(CancellationToken))
        {
            IQueryable<TEntity> query = _dbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return orderBy != null
                ? await orderBy(query).FirstOrDefaultAsync(cancellationToken)
                : await query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IPaginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null,
                                                           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                                           int page = 0,
                                                           int size = 20,
                                                           bool disableTracking = true,
                                                           CancellationToken cancellationToken = default(CancellationToken))
        {
            IQueryable<TEntity> query = _dbSet;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return orderBy != null
                ? await orderBy(query).ToPaginateAsync(page, size, cancellationToken)
                : await query.ToPaginateAsync(page, size, cancellationToken);
        }

        public async Task<IPaginate<TResult>> GetListAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
                                                                    Expression<Func<TEntity, bool>> predicate = null,
                                                                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                                    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                                                    int page = 1,
                                                                    int size = 20,
                                                                    bool disableTracking = true,
                                                                    CancellationToken cancellationToken = default(CancellationToken))
                    where TResult : class
        {

            IQueryable<TEntity> query = _dbSet;
            if (disableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);

            return orderBy != null
                ? await orderBy(query).Select(selector).ToPaginateAsync(page, size, cancellationToken)
                : await query.Select(selector).ToPaginateAsync(page, size, cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null,
                                                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                                            bool disableTracking = true,
                                                            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _dbSet;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return orderBy != null
                ? await orderBy(query).ToListAsync(cancellationToken)
                : await query.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
                                                                     Expression<Func<TEntity, bool>> predicate = null,
                                                                     Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                                     Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                                                     bool disableTracking = true,
                                                                     CancellationToken cancellationToken = default(CancellationToken))
                    where TResult : class
        {
            IQueryable<TEntity> query = _dbSet;
            if (disableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);

            return orderBy != null
                ? await orderBy(query).Select(selector).ToListAsync(cancellationToken)
                : await query.Select(selector).ToListAsync(cancellationToken);
        }

        public async Task AddAsync(TEntity entity,
                                   CancellationToken cancellationToken = default(CancellationToken))
                        => await _dbSet.AddAsync(entity, cancellationToken);

        public async Task AddAsync(params TEntity[] entities) => await _dbSet.AddRangeAsync(entities);

        public async Task AddAsync(IEnumerable<TEntity> entities,
                                   CancellationToken cancellationToken = default(CancellationToken))
                        => await _dbSet.AddRangeAsync(entities, cancellationToken);

        public async Task<IEnumerable<TEntity>> GetAllByBatchesAsync(Expression<Func<TEntity, bool>> predicate = null,
                                                                   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                                   Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                                                   bool disableTracking = true,
                                                                   int batchSize = PaginationConstants.PageSize,
                                                                   CancellationToken cancellationToken = default(CancellationToken))
        {
            int page = PaginationConstants.FirstPage;

            bool hasNext = true;

            List<TEntity> result = new List<TEntity>();

            while (hasNext)
            {
                var batchResult = await GetListAsync(predicate, orderBy, include, page, batchSize, disableTracking, cancellationToken);

                page = page + 1;

                hasNext = batchResult.HasNext;

                result.AddRange(batchResult.Items);
            }

            return result;
        }

        public async Task<IEnumerable<TResult>> GetAllByBatchesAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
                                                                      Expression<Func<TEntity, bool>> predicate = null,
                                                                      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                                      Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                                                      bool disableTracking = true,
                                                                      int batchSize = PaginationConstants.PageSize,
                                                                      CancellationToken cancellationToken = default) where TResult : class
        {
            int page = PaginationConstants.FirstPage;

            bool hasNext = true;

            List<TResult> result = new List<TResult>();

            while (hasNext)
            {
                var batchResult = await GetListAsync(selector, predicate, orderBy, include, page, batchSize, disableTracking, cancellationToken);

                hasNext = batchResult.HasNext;

                result.AddRange(batchResult.Items);
            }

            return result;
        }
    }
}
