using AutoMapper;
using FlasherData.Repositories.Interfaces;
using FlasherServer.Data.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlasherData.DataModels;

namespace FlasherServer.Pages.SubjectPage
{
    public partial class CreateSubject
    {
        SubjectDto NewSubject = new SubjectDto();
        [Inject]
        IUnitOfWork UnitOfWork { get; set; }
        [Inject]
        IMapper Mapper { get; set; }
        private void OnValidSumbit()
        {
            NewSubject.Id = 0;
            Subject _newSubject = Mapper.Map<Subject>(NewSubject);
            UnitOfWork.Subjects.Add(_newSubject);
            //UnitOfWork.Subjects.Add(Mapper.Map<Subject>(NewSubject));
        }
    }
}
