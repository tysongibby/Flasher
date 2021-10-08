using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FlasherShared.Data.Models;
using Flasher.Server.Data.Repositories.Interfaces;
using Flasher.Server.Data;

namespace Flasher.Server.Data.Repositories
{
    public class FlashCardRepository : BaseRepository<FlashCard>, IFlashCardRepository
    {       
        public FlashCardRepository(FlasherContext context) : base(context) {}

        public async Task<FlashCard> Update(FlashCard flashCardUpdate)
        {
            try
            {
                if (flashCardUpdate == null)
                {
                    throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
                }
                //TODO: add update entity
                //find flaschard to update
                FlashCard flashCardToUpdate = await FlasherContext.FlashCards.FindAsync(flashCardUpdate.Id);
                if (flashCardToUpdate != null)
                {
                    flashCardToUpdate.Front = flashCardUpdate.Front;
                    flashCardToUpdate.Back = flashCardUpdate.Back;
                    flashCardToUpdate.AnsweredCorrectly = flashCardUpdate.AnsweredCorrectly;
                    await FlasherContext.SaveChangesAsync();
                    
                    return flashCardToUpdate;
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


        public FlasherContext FlasherContext
        {
            get 
            {
                return _context as FlasherContext;
            }
        }
    }
}
