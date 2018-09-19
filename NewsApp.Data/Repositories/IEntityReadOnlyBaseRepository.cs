using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PattuSaree.Data.Repositories
{
    public interface IEntityReadOnlyBaseRepository<T> where T : class, new()
    {
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> All { get; }
        IQueryable<T> GetAll();
        // T GetSingle(long id); 
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        // T GetById(long entity);

        void Add(T entity);
        void Edit(T oldEntity, T newEntity);
        void DeleteRange(IEnumerable<T> entities);
    }
}