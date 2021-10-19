using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlasherApi.Data.Models;

namespace FlasherApi.Data.Repositories.Interfaces
{
    public interface IFlashCardRepository : IBaseRepository<FlashCard>
    {        
        IEnumerable<FlashCard> GetAllFlashCardsInSuperset(int supersetId);
        IEnumerable<FlashCard> GetAllFlashCardsInSet(int setId);
        public string GetSupersetTitle(int supersetId);
        public string GetSetTitle(int setId);
    }
}
