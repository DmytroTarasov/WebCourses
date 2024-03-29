﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccess.Abstract;
using EntityDTO.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DataAccess
{
    public class GenericRepository<TEntity, TKey>: IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey> 
    {
        private readonly DbSet<TEntity> _set;
        private readonly CoursesContext _db;
        
        public GenericRepository(CoursesContext db)
        {
            _db = db;
            _set = db.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _set.Add(entity);
            _db.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _set.Update(entity);
            _db.SaveChanges();
        }
        
        public async Task<TEntity> Get(TKey key)
        {
            return await _set.FindAsync(key);
        }
        
        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return await _set.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<TEntity> GetInclude(Expression<Func<TEntity, object>> includes, TKey key)
        {
            return await _set.Include(includes).FirstOrDefaultAsync(e => e.Id.Equals(key));
        }

        public async Task<bool> Exists(TKey key)
        {
            return await Get(key) != null;
        }
        
        public async Task<IEnumerable<TEntity>> GetN(int n)
        {
            return await _set.Take(n).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _set.ToListAsync();
        }
        
        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return await _set.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllInclude(Expression<Func<TEntity, object>> includes)
        {
            return await _set.Include(includes).ToListAsync();
        }

        public async Task Delete(TKey key)
        {
            _set.Remove(await Get(key));
            await _db.SaveChangesAsync();
        }
    }
}