using PattuSaree.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PattuSaree.Data.Repositories
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> All { get; }
        IQueryable<T> GetAll();
        T GetSingle(Guid id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void Delete(T entity);
        void Edit(T oldEntity, T newEntity);
        void AddRange(IEnumerable<T> entities);
        void SoftDelete(T entity);
        T GetById(Guid entity);
        void SoftDeleteRange(IEnumerable<T> entities);
        IQueryable<T> GetAllNoFilter();
        void DeleteRange(IEnumerable<T> entities);
    }
}
