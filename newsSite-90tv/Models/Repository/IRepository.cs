using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsSite.Infrustracture
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //void Insert(TEntity entity);
        //void Update(TEntity entity);
        //void Delete(object id);
        //void Delete(TEntity entity);
        //void Delete(Expression<Func<TEntity, bool>> where);
        //TEntity GetById(object Id);
        //IEnumerable<TEntity> GetAll();
        //TEntity Get(Expression<Func<TEntity, bool>> where);
        //TEntity GetFirst();
        //IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);
        
        //TEntity InCluded(Expression<Func<TEntity, bool>> where, string entity);

        //async  

        //Task<int> InsertAsync(TEntity entity);
        //Task<int> UpdateAsync(TEntity entity);
        //Task<int> DeleteAsync(object id);
        //Task<int> DeleteAsync(TEntity entity);
        //Task<int> DeleteAsync(Expression<Func<TEntity, bool>> where);

        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where);
        Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where);
    }
}
