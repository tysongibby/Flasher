using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Flasher.Server.Data.Repositories.Interfaces;

namespace Flasher.Server.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public BaseRepository(DbContext context)
        {
            Context = context;
        }

        public TEntity Get(int id)
        {
            try
            {
                return Context.Set<TEntity>().Find(id);
            }
            catch (Exception e)
            {
                throw new Exception($"Could not find entity: {e.Message}");
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return Context.Set<TEntity>().ToList();
            }
            catch (Exception e)
            {
                throw new Exception($"Could not find entities: {e.Message}");
            }
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                if (predicate == null)
                {
                    throw new ArgumentNullException($"{nameof(Add)} predicate must not be null");
                }
                return Context.Set<TEntity>().Where(predicate);
            }
            catch (Exception e)
            {
                throw new Exception($"Could not find entity: { e.Message}");
            }
        }

        public void Add(TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
                }
                Context.Set<TEntity>().Add(entity);
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception($"{nameof(entity)} could not be added: {e.Message}");
            }
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                if (entities == null)
                {
                    throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
                }
                Context.Set<TEntity>().AddRange(entities);
            }
            catch (Exception e)
            {
                throw new Exception($"{nameof(entities)} could not be added: {e.Message}");
            }
        }

        public void Remove(TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
                }
                Context.Set<TEntity>().Remove(entity);
            }
            catch (Exception e)
            {
                throw new Exception($"{nameof(entity)} could not be removed: {e.Message}");
            }
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            try
            {
                if (entities == null)
                {
                    throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
                }
                Context.Set<TEntity>().RemoveRange(entities);
            }
            catch (Exception e)
            {
                throw new Exception($"{nameof(entities)} could not be added: {e.Message}");
            }
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
            }
            try
            {
                return Context.Set<TEntity>().SingleOrDefault(predicate);
            }
            catch (Exception e)
            {
                throw new Exception($"could not be find entity: {e.Message}");
            }
        }

        public void SaveChanges(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
            }

            try
            {
                Context.Update(entity);
                //Context.SaveChanges();
                Context.SaveChangesAsync(); 
            }
            catch (Exception e)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {e.Message}");
            }
        }
    }
}
