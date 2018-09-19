using PattuSaree.Data.DbContext;
using PattuSaree.Data.Infrastructure;
using PattuSaree.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PattuSaree.Data.Repositories
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private PattuSareeContext _dataContext;
        //private DbFactory dbFactory;

        #region Properties
        protected IDbFactory DbFactory { get; }

        protected PattuSareeContext DbContext => _dataContext ?? (_dataContext = DbFactory.Init());

        //public EntityBaseRepository(IDbFactory dbFactory)
        //{
        //    DbFactory = new DbFactory();
        //}

        public EntityBaseRepository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
        }
        #endregion
        public virtual IQueryable<T> GetAll()
        {
            return DbContext.Set<T>().Where(x => x.IsDeleted == false);
        }
        public virtual IQueryable<T> All => GetAll();

        public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            var query = DbContext.Set<T>().Where(x => x.IsDeleted == false);
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public T GetSingle(Guid keyId)
        {
            return GetAll().FirstOrDefault(x => x.KeyId == keyId);
        }
        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Where(predicate).Where(x => x.IsDeleted == false);
        }

        public virtual void Add(T entity)
        {
            entity.IsDeleted = false;
            entity.CreatedDate = DateTime.Now;

            DbContext.Set<T>().Add(entity);
            
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = false;
                entity.CreatedDate = DateTime.UtcNow;

                DbContext.Set<T>().Add(entity);
            }
        }

        public virtual void Edit(T oldEntity, T newEntity)
        {
            newEntity.KeyId = oldEntity.KeyId;
            newEntity.IsDeleted = false;
            newEntity.CreatedDate = oldEntity.CreatedDate;
           
            DbContext.Entry(oldEntity).CurrentValues.SetValues(newEntity);
            
        }

        public virtual void SoftDelete(T entity)
        {
            entity.IsDeleted = true;
            //entity.ModifiedDate = DateTime.UtcNow;
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            dbEntityEntry.State = EntityState.Modified;
            
        }

        public virtual void SoftDeleteRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
                entity.DeletedDate = DateTime.UtcNow;
                DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
                dbEntityEntry.State = EntityState.Modified;
                
            }
        }


        #region Get Data By Id..
       
        public virtual T GetById(Guid entity)
        {
            var abc = DbContext.Set<T>().FirstOrDefault(x => (x.KeyId == entity) && (x.IsDeleted == false));
            return abc;
        }

        public void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
                dbEntityEntry.State = EntityState.Deleted;
            }
        }

        public virtual IQueryable<T> GetAllNoFilter()
        {
            return DbContext.Set<T>();
        }
        #endregion
    }
}
