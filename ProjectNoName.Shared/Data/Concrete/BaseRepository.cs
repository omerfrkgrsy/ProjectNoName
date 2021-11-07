﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using ProjectNoName.Shared.Data.Abstract;
using ProjectNoName.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNoName.Shared.Data.Concrete
{
    public class BaseRepository<T> :IBaseRepository<T> where T : class, IEntity, new()
    {
        protected readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            this._context = context;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public async Task<IList<T>> AllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IList<T>> WhereAsync(Expression<Func<T, bool>> where)
        {
            return await _context.Set<T>().Where(where).ToListAsync();
        }

        public async Task<IList<T>> OrderByAsync<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc)
        {
            if (isDesc)
                return await _context.Set<T>().OrderByDescending(orderBy).ToListAsync();

            return await _context.Set<T>().OrderBy(orderBy).ToListAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await this._context.SaveChangesAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
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

    }
}