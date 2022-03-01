using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNoName.Core.Service.Abstract
{
    public interface IBaseService<T>
    {
        Task<T> Get(int id);

        Task<bool> Delete(int id);

        Task<T> Insert(T entity);

        Task<T> Update(T entity);

        Task<bool> CheckById(int id);
        IQueryable<T> GetAllQueryable();
        Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null);
    }
}
