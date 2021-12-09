using FlasherWeb.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherWeb.Services.Interfaces
{
    public interface IFlashcardService
    {
        Task<Flashcard> Get(int id);
        Task<List<Flashcard>> GetAll();
        Task<List<Flashcard>> GetAllFlashcardsForSubject(int id);
        Task<List<Flashcard>> GetAllFlashcardsForCategory(int id);
        Task<string> Create(Flashcard flashcardToCreate);
        Task<string> Update(Flashcard flashcardUpdate);
        Task<string> Delete(Flashcard flashcardToDelete);
    }
}
