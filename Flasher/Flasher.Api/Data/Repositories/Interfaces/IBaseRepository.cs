using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Flasher.Server.Data.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}


// *** ASYNC VERSION ***
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Threading.Tasks;

//namespace UltiLuv.API.Repositories.Interfaces
//{
//    public interface IRepository<TEntity> where TEntity : class
//    {
//        TEntity Get(int id);
//        IEnumerable<TEntity> GetAll();
//        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

//        //IQueryable<TEntity> Query(string queryString);

//        // This method was not in the videos, but I thought it would be useful to add.
//        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

//        Task<TEntity> AddAsync(TEntity entity);
//        Task<TEntity> AddRangeAsync(IEnumerable<TEntity> entities);
//        Task<TEntity> UpdateAsync();

//        Task<TEntity> RemoveAsync(TEntity entity);
//        Task<TEntity> RemoveRangeAsync(IEnumerable<TEntity> entities);
//    }
//}