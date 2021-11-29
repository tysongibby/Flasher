using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FlasherData.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(int id);
        //TEntity Get(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        //IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        Task<bool> ExistsAsync(int id);
        //bool Exists(int id);
        Task<TEntity> WhereSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        //Task<TEntity> WhereSingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<int> AddAsync(TEntity entity);
        //int Add(TEntity entity);
        Task<List<int>> AddRangeAsync(IEnumerable<TEntity> entities);
        //List<int> AddRange(IEnumerable<TEntity> entities);
        int Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}