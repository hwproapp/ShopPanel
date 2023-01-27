using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using newsSite90tv.Models;

using System;
using System.Collections.Generic;

using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace StatisticsSite.Infrustracture
{
    public abstract class Repository<TEntity> : IRepository<TEntity> ,IDisposable
        where TEntity : class
    {
        private readonly  ApplicationDbContext  db;
        private DbSet<TEntity> dbSet => db.Set<TEntity>();

      
        public Repository(ApplicationDbContext dbContext)
        {
            this.db = dbContext;
        }
       

        public virtual void Delete(object id)
        {
            var entity = GetById(id);
            if (entity == null) throw new ArgumentException("entity");
            dbSet.Remove(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> where)
        {
            IEnumerable<TEntity> objects = dbSet.Where(where).AsEnumerable();
            foreach (TEntity obj in objects) dbSet.Remove(obj);
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            return await dbSet.Where(where).FirstOrDefaultAsync();
        }

        public virtual TEntity GetById(object Id)
        {
            return dbSet.Find(Id);
        }

        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        //........

       

        public virtual async Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where)
        {
            return await dbSet.Where(where).ToListAsync();
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }
        public virtual void Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentException("entity");
            dbSet.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
        }

        public virtual TEntity GetFirst()
        {
            return dbSet.FirstOrDefault();
        }
        public TEntity InCluded(Expression<Func<TEntity, bool>> where,string entity)
        {
            return dbSet.Where(where).Include(entity).FirstOrDefault();
        }
      

        #region Dispose
        protected bool isDisposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                db.Dispose();
            }

            isDisposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}