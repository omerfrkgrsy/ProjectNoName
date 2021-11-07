using Microsoft.EntityFrameworkCore.Storage;
using ProjectNoName.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNoName.Shared.Data.Abstract
{
    public interface IBaseRepository<T> where T : class ,IEntity, new()
    {
        IDbContextTransaction BeginTransaction();

        Task<IList<T>> AllAsync();

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
