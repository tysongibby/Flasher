using FlasherWeb.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherWeb.Services.Interfaces
{
    interface ISupersetService
    {
        Task<Superset> Get(int id);
        Task<List<Superset>> GetAll();
        Task<Superset> Create(Superset SupersetToCreate);
        Task<Superset> Update(Superset SupersetUpdate);
        Task<string> Delete(Superset SupersetToDelete);
    }
}
