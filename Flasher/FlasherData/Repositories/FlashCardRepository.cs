using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FlasherData.Models;
using FlasherData.Repositories.Interfaces;
using FlasherData;
using FlasherData.Context;

namespace FlasherData.Repositories
{
    public class FlashCardRepository : GenericRepository<FlashCardModel>, IFlashCardRepository
    {       
        public FlashCardRepository(FlasherContext context) : base(context) {}
        public FlasherContext FlasherContext
        {
            get
            {
                return _context as FlasherContext;
            }
        }

        //public override int Update(Flashcard flashCardUpdate)
        //{
        //    try
        //    {
        //        if (flashCardUpdate == null)
        //        {
        //            throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
        //        }
        //        //TODO: add update entity to BaseRepository.cs if possible                
        //        Flashcard flashCardToUpdate = FlasherContext.FlashCards.Find(flashCardUpdate.Id);
        //        if (flashCardToUpdate != null)
        //        {
        //            flashCardToUpdate.Title = flashCardUpdate.Title;
        //            flashCardToUpdate.Front = flashCardUpdate.Front;
        //            flashCardToUpdate.Back = flashCardUpdate.Back;
        //            flashCardToUpdate.AnsweredCorrectly = flashCardUpdate.AnsweredCorrectly;
        //            flashCardToUpdate.SupersetId = flashCardUpdate.SupersetId;
        //            flashCardToUpdate.SetId = flashCardUpdate.SetId;
        //            FlasherContext.SaveChangesAsync();                    
        //        }
        //        return flashCardToUpdate.Id;

        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception($"Flash card could not be updated: {e.Message}");
        //    }
        //}

        public IEnumerable<FlashCardModel> GetAllFlashCardsInSuperset(int supersetId)
        {           
            IEnumerable<FlashCardModel> _flashCards = _context.Set<FlashCardModel>().Where(fc => fc.SupersetId == supersetId);         
            return _flashCards;
        }

        public IEnumerable<FlashCardModel> GetAllFlashCardsInSet(int setId)
        {
            IEnumerable<FlashCardModel> _flashCards = _context.Set<FlashCardModel>().Where(fc => fc.SetId == setId);
            return _flashCards;
        }

        public string GetSupersetTitle(int supersetId)
        {
           var title = _context.Set<SupersetModel>().Where(s => s.Id == supersetId).FirstOrDefault().Title;
           return title;
        }

        public string GetSetTitle(int setId)
        {
            var title = _context.Set<SetModel>().Where(s => s.Id == setId).FirstOrDefault().Title;
            return title;
        }


    }
}
