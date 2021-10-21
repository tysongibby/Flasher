using FlasherWeb.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherWeb.Services.Interfaces
{
    public interface IFlashCardService
    {
        Task<FlashCard> Get(int id);
        Task<List<FlashCard>> GetAll();
        Task<List<FlashCard>> GetAllFlashCardsInSuperset(int id);
        Task<List<FlashCard>> GetAllFlashCardsInSet(int id);
        Task<FlashCard> Create(FlashCard flashCardToCreate);
        Task<string> Update(FlashCard flashCardUpdate);
        Task<string> Delete(FlashCard flashCardToDelete);
    }
}
