using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Update(T entity);
        Task<T> Get(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<T>> All(CancellationToken cancellationToken);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate,CancellationToken cancellationToken);
        Task SaveChanges(CancellationToken cancellationToken);
    }
}