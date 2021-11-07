using ProjectNoName.Shared.Data.Abstract;
using ProjectNoName.Shared.Entity;
using ProjectNoName.Shared.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNoName.Shared.Service.Concrete
{
    public abstract class AbstractDalService<T>:IBaseService<T> where T : class, IEntity,new()
    {
        public IBaseRepository<T> _dal;

        public AbstractDalService(IBaseRepository<T> dal)
        {
            _dal = dal;
        }

        public async Task<bool> CheckById(int id)
        {
            return await _dal.AnyAsync(id);
        }

        public async virtual Task<bool> Delete(int id)
        {
            var currentData = await _dal.GetAsync(id);

            if (currentData != null)
            {
                return await _dal.DeleteAsync(currentData);
            }
            else
            {
                return false;
            }
        }

        public async Task<T> Get(int id)
        {
            return await _dal.GetAsync(id);
        }

        public async virtual Task<IList<T>> GetAll()
        {
            return await _dal.AllAsync();
        }

        public virtual IQueryable<T> GetAllQueryable()
        {
            return _dal.All();
        }
        public async virtual Task<T> Insert(T entity)
        {
            return await _dal.AddAsync(entity);
        }

        public async virtual Task<T> Update(T entity)
        {
            return await _dal.UpdateAsync(entity);
        }
    }
}
