using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNoName.Shared.Service.Abstract
{
    public interface IBaseService<T>
    {
        Task<T> Get(int id);

        Task<bool> Delete(int id);

        Task<IList<T>> GetAll();
        Task<T> Insert(T entity);

        Task<T> Update(T entity);

        Task<bool> CheckById(int id);
    }
}
