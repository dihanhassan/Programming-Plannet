using BlogPost.Data;
using BlogPost.Domain.Entities;
using BlogPost.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Repo
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        #region CTOR
        private readonly EFDbContext _context;

        public BaseRepository(EFDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        #endregion CTOR

        #region GET METHOD

        public virtual IQueryable<T> Active()
        {
            return _context.Set<T>().Where(x => x.IsDeleted == false).AsNoTracking();
        }

        public async virtual Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().FindAsync(new object[] { id }, cancellationToken);
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).AsNoTracking();
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return _context.Set<T>().AsNoTracking();
        }


        public Task<IQueryable<T>> GetPagedDataAsync(IQueryable<T> query, int pageIndex, int pageSize)
        {

            // Calculate the number of items to skip
            var skip = (pageIndex - 1) * pageSize;

            // Create a paginated query
            var pagedQuery = query
                .Skip(skip)
                .Take(pageSize);

            // Return the paginated query as a Task
            return Task.FromResult(pagedQuery);
        }

        #endregion GET METHOD

        #region SAVE METHOD
        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _context.Set<T>().AddAsync(entity, cancellationToken);
            return entity;
        }

        public async Task<List<T>> AddRangeAsync(List<T> entities, CancellationToken cancellationToken = default)
        {
            await _context.Set<T>().AddRangeAsync(entities, cancellationToken);
            return entities;
        }
        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        #endregion SAVE METHOD

        #region UPDATE METHOD
        public Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            return Task.CompletedTask;
        }
        #endregion UPDATE METHOD

        #region DELETE METHOD
        public Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }
        public async Task RemoveRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            _context.Set<T>().RemoveRange(entities);
            await _context.SaveChangesAsync(cancellationToken);
        }

        #endregion DELETE METHOD
    }
}
