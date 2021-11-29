using FlasherData.Repositories.Interfaces;
using FlasherData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlasherData.Context;

namespace FlasherData.Repositories
{
    public class SetRepository : BaseRepository<Set>, ISetRepository
    {
        public SetRepository(FlasherContext context) : base(context) { }
        public FlasherContext FlasherContext
        {
            get
            {
                return _context as FlasherContext;
            }
        }

        public async Task<Superset> GetSuperset(int id)
        {
            var set = FlasherContext.Sets.FindAsync(id).Result;
            if (set is not null)
            {
                Superset superset = await FlasherContext.Supersets.FindAsync(set.SupersetId);
                return superset;
            }
            else
            {
                throw new Exception($"Supser set {id} coudl not be found.");
            }
        }

        //public override int Update(Set setUpdate)
        //{
        //    try
        //    {
        //        if (setUpdate == null)
        //        {
        //            throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
        //        }
        //        //TODO: add update entity to BaseRepository.cs if possible                
        //        Set setToUpdate = FlasherContext.Sets.Find(setUpdate.Id);
        //        if (setToUpdate != null)
        //        {
        //            setToUpdate.Title = setUpdate.Title;
        //            setToUpdate.SupersetId = setUpdate.SupersetId;
        //            FlasherContext.SaveChangesAsync();
        //        }
        //        return setToUpdate.Id;

        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception($"Flash card could not be updated: {e.Message}");
        //    }


        //}

    }
}
