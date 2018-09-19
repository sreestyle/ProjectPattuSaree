using PattuSaree.Data.DbContext;
using PattuSaree.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;


namespace PattuSaree.Data.Repositories
{
    public class EntityReadOnlyBaseRepository<T> : IEntityReadOnlyBaseRepository<T> where T : class, new()
    {
        private PattuSareeContext _dataContext;

        #region Properties
        protected IDbFactory DbFactory { get; }

        protected PattuSareeContext DbContext => _dataContext ?? (_dataContext = DbFactory.Init());

        public EntityReadOnlyBaseRepository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
        }
        #endregion
        public virtual IQueryable<T> GetAll()
        {
            return DbContext.Set<T>();
        }
        public virtual IQueryable<T> All => GetAll();

        public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            var query = DbContext.Set<T>().AsQueryable();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        //public T GetSingle(long id)
        //{
        //    return GetAll().FirstOrDefault(x => x. == id);
        //}
        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Where(predicate).AsQueryable();
        }
        #region Get Data By Id..


        
        public virtual void Add(T entity)
        {
            DbContext.Set<T>().Add(entity);
            
        }

        
        #endregion

        public virtual void Edit(T oldEntity, T newEntity)
        {
            
            DbContext.Entry(oldEntity).CurrentValues.SetValues(newEntity);
            
        }


        public void DeleteRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
                dbEntityEntry.State = EntityState.Deleted;
            }
        }
    }
}
