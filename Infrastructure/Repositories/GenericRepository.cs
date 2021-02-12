using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.Common.Interfaces;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public abstract class GenericRepository<T> 
        : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

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

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>()
                .AsQueryable()
                .Where(predicate).ToList();
        }

        public virtual T Get(Guid id)
        {
            return _context.Find<T>(id);
        }
        
        public virtual IEnumerable<T> All()
        {
            return _context.Set<T>()
                .ToList();
        }

        public virtual T Update(T entity)
        {
            return _context.Update(entity)
                .Entity;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}