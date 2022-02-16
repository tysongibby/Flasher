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
        private SubjectDto NewSubject = new SubjectDto();
        [Inject]
        private NavigationManager NavManager { get; set; }
        [Inject]
        private IUnitOfWork UnitOfWork { get; set; }
        [Inject]
        private IMapper Mapper { get; set; }
        [Parameter]
        public string NewTestName { get; set; }

        private Test NewTest { get; set; } = new Test();
        private int NewTestId { get; set; }


        private void OnValidSumbit()
        {
            // create new subject
            NewSubject.Id = 0;
            Subject _newSubject = Mapper.Map<Subject>(NewSubject);
            int newSubjectId = UnitOfWork.Subjects.Add(_newSubject);
            NewTest.SubjectId = newSubjectId;

            // create new test
            NewTest.Name = NewTestName;
            NewTestId = UnitOfWork.Tests.Add(NewTest);

            // navigate to next page
            NavManager.NavigateTo($"/testcategory/{NewTestId}");
        }
    }
}
