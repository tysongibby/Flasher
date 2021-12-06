﻿using FlasherWeb.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherWeb.Services.Interfaces
{
    public interface IFlashCardService
    {
        Task<Flashcard> Get(int id);
        Task<List<Flashcard>> GetAll();
        Task<List<Flashcard>> GetAllFlashCardsForSubject(int id);
        Task<List<Flashcard>> GetAllFlashCardsForCategory(int id);
        Task<string> Create(Flashcard flashCardToCreate);
        Task<string> Update(Flashcard flashCardUpdate);
        Task<string> Delete(Flashcard flashCardToDelete);
    }
}
