using FlasherWeb.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherWeb.Services.Interfaces
{
    interface ISetService
    {
        Task<Set> Get(int id);
        Task<List<Set>> GetAll();
        Task<Set> Create(Set SetToCreate);
        Task<Set> Update(Set SetUpdate);
        Task<string> Delete(Set SetToDelete);
    }
}
