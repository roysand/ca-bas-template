using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public abstract class GenericRepository<T> 
        : IRepository<T> where T : class
    {
        public readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public virtual T Add(T entity)
        {
            return _context
                .Add(entity)
                .Entity;
        }

        public  virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _context.Set<T>()
                .AsQueryable()
                .Where(predicate).ToListAsync(cancellationToken);
        }

        public virtual async  Task<T> Get(Guid id, CancellationToken cancellationToken)
        {
            return await _context.FindAsync<T>(id, cancellationToken);
        }
        
        public virtual async Task<IEnumerable<T>> All(CancellationToken cancellationToken)
        {
            return await _context.Set<T>()
                .ToListAsync(cancellationToken);
        }

        public virtual T Update(T entity)
        {
            return _context.Update(entity)
                .Entity;
        }

        public async Task SaveChanges(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}