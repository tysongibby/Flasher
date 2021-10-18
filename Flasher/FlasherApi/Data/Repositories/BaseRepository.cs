using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FlasherApi.Data.Repositories.Interfaces;

namespace FlasherApi.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a single instance of the entity type</returns>
        public virtual async Task<TEntity> Get(int id)
        {
            try
            {                
                return await _context.Set<TEntity>().FindAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception($"Could not find entity: {e.Message}");
            }
        }

        /// <summary>
        /// Returns all entities in the dbcontext
        /// </summary>
        /// <returns>A List of the entity type</returns>
        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            try
            {                
                return await _context.Set<TEntity>().ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Could not find entities: {e.Message}");
            }
        }

        //TODO: discover how to make this method async
        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                if (predicate == null)
                {
                    throw new ArgumentNullException($"{nameof(Add)} predicate must not be null");
                }
                return _context.Set<TEntity>().Where(predicate);
            }
            catch (Exception e)
            {
                throw new Exception($"Could not find entity: { e.Message}");
            }
        }

        public virtual async Task<bool> Exists(int id)
        {
            try
            {
                var response = await _context.Set<TEntity>().FindAsync(id);
                if (response != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Could not find entity: {e.Message}");
            }
        }

        /// <summary>
        /// Returns a single entity based on a predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>Of entity type</returns>
        public virtual async Task<TEntity> FindSingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
            }
            try
            {
                return await _context.Set<TEntity>().SingleOrDefaultAsync(predicate);
            }
            catch (Exception e)
            {
                throw new Exception($"could not be find entity: {e.Message}");
            }
        }


        /// <summary>
        /// Adds new entity to dbcontext, returns an integer greater than zero if successful
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>An integer type</returns>
        public virtual async Task<int> Add(TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
                }
                _context.Set<TEntity>().Add(entity);
                ;
                int entitiesAdded = await _context.SaveChangesAsync();
                return entitiesAdded;
            }
            catch (Exception e)
            {
                throw new Exception($"{nameof(entity)} could not be added: {e.Message}");
            }
        }

        /// <summary>
        /// Adds new entities to dbcontext, returns an integer greater than zero if successful
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>An integer type</returns>
        public virtual async Task<int> AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                if (entities == null)
                {
                    throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
                }
                _context.Set<TEntity>().AddRange(entities);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"{nameof(entities)} could not be added: {e.Message}");
            }
        }

        //TODO: disocver how to remove/delete entities with async
        public virtual void Remove(TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
                }
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception($"{nameof(entity)} could not be removed: {e.Message}");
            }
        }

        //TODO: discover how to remove/delete entities with async
        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            try
            {
                if (entities == null)
                {
                    throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
                }
                _context.Set<TEntity>().RemoveRange(entities);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception($"{nameof(entities)} could not be added: {e.Message}");
            }
        }


        /// <summary>
        /// Saves changes to dbcontext for an entity, returns an integer greater than zero if successful
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>An integer type</returns>
        public virtual async Task<int> SaveChanges(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
            }

            try
            {
                _context.Update(entity);                
                int entitiesChanged = await _context.SaveChangesAsync();
                return entitiesChanged;
            }
            catch (Exception e)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {e.Message}");
            }
        }
    }
}
