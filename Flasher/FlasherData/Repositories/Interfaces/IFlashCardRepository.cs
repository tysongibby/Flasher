using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlasherData.Models;

namespace FlasherData.Repositories.Interfaces
{
    public interface IFlashCardRepository : IBaseRepository<FlashCardModel>
    {        
        public IEnumerable<FlashCardModel> GetAllFlashCardsInSuperset(int supersetId);
        public IEnumerable<FlashCardModel> GetAllFlashCardsInSet(int setId);
        public string GetSupersetTitle(int supersetId);
        public string GetSetTitle(int setId);
    }
}
