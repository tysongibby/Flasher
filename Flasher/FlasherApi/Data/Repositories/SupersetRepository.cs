using FlasherApi.Data.Repositories.Interfaces;
using FlasherApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherApi.Data.Repositories
{
    public class SupersetRepository : BaseRepository<Superset>, ISupersetRepository
    {
        public SupersetRepository(FlasherContext context) : base(context) { }
        public FlasherContext FlasherContext
        {
            get
            {
                return _context as FlasherContext;
            }
        }

        public override async Task<Superset> Update(Superset supersetUpdate)
        {
            try
            {
                if (supersetUpdate == null)
                {
                    throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
                }
                //TODO: add update entity to BaseRepository.cs if possible                
                Superset supersetToUpdate = await FlasherContext.Supersets.FindAsync(supersetUpdate.Id);
                if (supersetToUpdate != null)
                {
                    supersetToUpdate.Title = supersetUpdate.Title;
                    await FlasherContext.SaveChangesAsync();

                    return supersetToUpdate;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Flash card could not be updated: {e.Message}");
            }


        }
    }
}
