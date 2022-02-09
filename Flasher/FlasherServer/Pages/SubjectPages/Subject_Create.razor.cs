using AutoMapper;
using FlasherData.Repositories.Interfaces;
using FlasherServer.Data.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlasherData.DataModels;

namespace FlasherServer.Pages.SubjectPages
{
    public partial class Subject_Create
    {
        SubjectDto NewSubject = new SubjectDto();
        [Inject]
        NavigationManager NavManager { get; set; }
        [Inject]
        IUnitOfWork UnitOfWork { get; set; }
        [Inject]
        IMapper Mapper { get; set; }
        private void OnValidSumbit()
        {
            NewSubject.Id = 0;
            Subject _newSubject = Mapper.Map<Subject>(NewSubject);
            int newSubjectId = UnitOfWork.Subjects.Add(_newSubject);

            NavManager.NavigateTo($"/category/create/{newSubjectId}");
        }
    }
}
