﻿using FlasherApi.Data.Repositories.Interfaces;
using FlasherApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherApi.Data.Repositories
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

        public override async Task<Set> Update(Set setUpdate)
        {
            try
            {
                if (setUpdate == null)
                {
                    throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
                }
                //TODO: add update entity to BaseRepository.cs if possible                
                Set setToUpdate = await FlasherContext.Sets.FindAsync(setUpdate.Id);
                if (setToUpdate != null)
                {
                    setToUpdate.Title = setUpdate.Title;
                    setToUpdate.SupersetId = setUpdate.SupersetId;
                    await FlasherContext.SaveChangesAsync();

                    return setToUpdate;
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
