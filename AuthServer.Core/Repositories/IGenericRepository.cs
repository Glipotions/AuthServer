﻿using System.Linq.Expressions;

namespace AuthServer.Core.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity: class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        void Remove(TEntity entity);

        /// _context.Entry(entity).state=EntityState.Modified
        TEntity Update(TEntity entity);
        
    }
}
