using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FlasherApi.Data.Models;
using FlasherApi.Data.Repositories.Interfaces;
using FlasherApi.Data;

namespace FlasherApi.Data.Repositories
{
    public class FlashCardRepository : BaseRepository<FlashCard>, IFlashCardRepository
    {       
        public FlashCardRepository(FlasherContext context) : base(context) {}
        public FlasherContext FlasherContext
        {
            get
            {
                return _context as FlasherContext;
            }
        }

        public override async Task<FlashCard> Update(FlashCard flashCardUpdate)
        {
            try
            {
                if (flashCardUpdate == null)
                {
                    throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
                }
                //TODO: add update entity to BaseRepository.cs if possible                
                FlashCard flashCardToUpdate = await FlasherContext.FlashCards.FindAsync(flashCardUpdate.Id);
                if (flashCardToUpdate != null)
                {
                    flashCardToUpdate.Title = flashCardUpdate.Title;
                    flashCardToUpdate.Front = flashCardUpdate.Front;
                    flashCardToUpdate.Back = flashCardUpdate.Back;
                    flashCardToUpdate.AnsweredCorrectly = flashCardUpdate.AnsweredCorrectly;
                    flashCardToUpdate.SupersetId = flashCardUpdate.SupersetId;
                    flashCardToUpdate.SetId = flashCardUpdate.SetId;
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
       
        public IEnumerable<FlashCard> GetAllFlashCardsInSuperset(int supersetId)
        {           
            IEnumerable<FlashCard> _flashCards = _context.Set<FlashCard>().Where(fc => fc.SupersetId == supersetId);         
            return _flashCards;
        }

        public IEnumerable<FlashCard> GetAllFlashCardsInSet(int setId)
        {
            IEnumerable<FlashCard> _flashCards = _context.Set<FlashCard>().Where(fc => fc.SetId == setId);
            return _flashCards;
        }

        public string GetSupersetTitle(int supersetId)
        {
           var title = _context.Set<Superset>().Where(s => s.Id == supersetId).FirstOrDefault().Title;
           return title;
        }

        public string GetSetTitle(int setId)
        {
            var title = _context.Set<Set>().Where(s => s.Id == setId).FirstOrDefault().Title;
            return title;
        }


    }
}
