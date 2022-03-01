using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using ProjectNoName.Core.Data.Abstract;
using ProjectNoName.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNoName.Core.Data.Concrete
{
    public class EfBaseRepository<T> :IEfBaseRepository<T> where T : class, IEntity, new()
    {
        protected readonly DbContext _context;

        public EfBaseRepository(DbContext context)
        {
            this._context = context;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public async Task<int> SaveAsync()
        {
            return await this._context.SaveChangesAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _context.Remove(entity);
            return await SaveAsync() > -1;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => { _context.Set<T>().Update(entity); });
            return entity;
        }

        public async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }
        public IQueryable<T> All()
        {
            DbSet<T> dbSet = _context.Set<T>();

            IQueryable<T> query = dbSet.AsQueryable();
            return query;
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> where=null)
        {
            return await _context.Set<T>().AnyAsync(where);
        }

    }
}
