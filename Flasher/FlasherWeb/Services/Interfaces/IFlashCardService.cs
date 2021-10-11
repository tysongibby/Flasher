﻿using FlasherWeb.Services.Models;
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
        Task<FlashCard> Create(FlashCard flashCardToCreate);
        Task<FlashCard> Update(FlashCard flashCardUpdate);
        Task<string> Delete(FlashCard flashCardToDelete);
    }
}
