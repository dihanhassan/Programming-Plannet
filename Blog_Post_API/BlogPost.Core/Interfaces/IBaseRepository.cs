using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Domain.Interfaces
{
    public interface IBaseRepository<T>
    {
        #region Get
        IQueryable<T> Active();
        Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IQueryable<T>> GetAllAsync();
        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);
        Task<IQueryable<T>> GetPagedDataAsync(IQueryable<T> query, int pageIndex, int pageSize);

        #endregion Get

        #region Save
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task<List<T>> AddRangeAsync(List<T> entities, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
        #endregion Save

        #region Update
        Task UpdateAsync(T entity);
        #endregion Update

        #region Delete
        Task DeleteAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        #endregion Delete
    }
}
