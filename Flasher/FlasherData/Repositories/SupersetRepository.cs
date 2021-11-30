using FlasherData.Repositories.Interfaces;
using FlasherData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlasherData.Context;

namespace FlasherData.Repositories
{
    public class SupersetRepository : BaseRepository<SupersetModel>, ISupersetRepository
    {
        public SupersetRepository(FlasherContext context) : base(context) { }
        public FlasherContext FlasherContext
        {
            get
            {
                return _context as FlasherContext;
            }
        }

        public override int Update(SupersetModel supersetUpdate)
        {
            try
            {
                if (supersetUpdate == null)
                {
                    throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
                }
                //TODO: add update entity to BaseRepository.cs if possible                
                SupersetModel supersetToUpdate = FlasherContext.Supersets.Find(supersetUpdate.Id);
                if (supersetToUpdate != null)
                {
                    supersetToUpdate.Title = supersetUpdate.Title;
                    FlasherContext.SaveChangesAsync();
                }
                return supersetToUpdate.Id;
            }
            catch (Exception e)
            {
                throw new Exception($"Flash card could not be updated: {e.Message}");
            }


        }
    }
}
