using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace GoIn.DataAccess.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        #region Fields

        internal DbSet<T> dbSet;
        internal DbContext dbContext;

        #endregion

        #region Constructors

        public BaseRepository(DbContext dbContext)
        {
            if (dbContext == null) throw new ArgumentNullException("context");
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<T>();
        }

        #endregion

        #region Methods

        public bool Delete(int id)
        {
            bool result = false;

            T entity = this.Single(id);


            if (null != entity)
            {
                this.Delete(entity);
                result = true;
            }
            return result;
        }

        private void Delete(T entity)
        {
            if(dbContext.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
        }

        public int Delete(List<int> ids)
        {
            int result = 0;
            foreach (int id in ids)
            {
                T entity = this.Single(id);

                if (null != entity)
                {
                    if (this.dbContext.Entry(entity).State == EntityState.Detached)
                    {
                        dbSet.Attach(entity);
                    }
                    dynamic obj = dbSet.Remove(entity);
                    result++;
                }
            }
            return result;
        }

        public bool Exists(object primaryKey)
        {
            return dbSet.Find(primaryKey) == null ? false : true;
        }

        public IQueryable<T> GetAll()
        {
            return dbSet.AsNoTracking();
        }

        public int Insert(T entity)
        {
            dynamic obj = dbSet.Add(entity);
            return obj.Id;
        }

        public int Insert(List<T> entities)
        {
            int result = 0;
            foreach (T entity in entities)
            {
                dbSet.Add(entity);
                result++;
            }
            return result;
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> filter)
        {
            return dbSet.Where(filter);
        }

        public IQueryable<T> QueryObjectGraph(Expression<Func<T, bool>> filter, string children)
        {
            return dbSet.Include(children).Where(filter);
        }

        public T Single(object primaryKey)
        {
            var dbResult = dbSet.Find(primaryKey);
            return dbResult;
        }

        public T SingleOrDefault(object primaryKey)
        {
            var dbResult = dbSet.Find(primaryKey);
            return dbResult;
        }

        public void Update(T Entity)
        {
            dbSet.Attach(Entity);
            this.dbContext.Entry(Entity).State = EntityState.Modified;
        }

        public void Update(List<T> Entities)
        {
            foreach (T entity in Entities)
            {
                dbSet.Attach(entity);
                this.dbContext.Entry(entity).State = EntityState.Modified;
            }
        }

        #endregion
    }
}