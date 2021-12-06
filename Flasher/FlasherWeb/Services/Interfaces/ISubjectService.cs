using FlasherWeb.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherWeb.Services.Interfaces
{
    interface ISubjectService
    {
        Task<Subject> Get(int id);
        Task<List<Subject>> GetAll();
        Task<Subject> Create(Subject SubjectToCreate);
        Task<Subject> Update(Subject SubectUpdate);
        Task<string> Delete(Subject SubjectToDelete);
    }
}
