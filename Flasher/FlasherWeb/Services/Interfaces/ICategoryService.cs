using FlasherWeb.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherWeb.Services.Interfaces
{
    interface ICategoryService
    {
        Task<Category> Get(int id);
        Task<List<Category>> GetAll();
        Task<Category> Create(Category CategoryToCreate);
        Task<Category> Update(Category CategoryUpdate);
        Task<string> Delete(Category CategoryToDelete);
    }
}
