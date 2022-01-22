using Microsoft.EntityFrameworkCore.Storage;
using ProjectNoName.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNoName.Core.Data.Abstract
{
    public interface IEfBaseRepository<T> where T : class ,IEntity, new()
    {
        IDbContextTransaction BeginTransaction();

        Task<IList<T>> AllAsync(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includeProperties);

        Task<IList<T>> WhereAsync(Expression<Func<T, bool>> where);

        Task<IList<T>> OrderByAsync<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc);
       
        Task<int> SaveAsync();

        Task<T> AddAsync(T entity);

        Task<bool> DeleteAsync(T entity);

        Task<T> UpdateAsync(T entity);

        IQueryable<T> All();

        Task<T> GetAsync(int id);

        Task<bool> AnyAsync(int id);
    }
}
