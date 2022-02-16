using FlasherData.Repositories.Interfaces;
using FlasherServer.Data.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using FlasherData.DataModels;
using Microsoft.AspNetCore.Components.Web;
using FlasherServer.Pages.TestPages.Models;

namespace FlasherServer.Pages.TestPages
{
    public partial class TestSubject
    {
        [Inject]
        private IUnitOfWork UnitOfWork { get; set; }
        [Inject]
        private IMapper Mapper { get; set; }
        [Inject]
        private NavigationManager NavManager { get; set; }
        private IList<SubjectDto> Subjects { get; set; } = new List<SubjectDto>();
        private SubjectDto SelectedSubject { get; set; } = new SubjectDto();
        private Test NewTest { get; set; } = new Test();
        private int NewTestId { get; set; }
        private string NewTestName { get; set; }
        private TestSubjectPage Page { get; set; } = new TestSubjectPage();
        private int SelectedSubjectId { get; set; }
       

        protected override void OnInitialized()
        {   
            // initialize page data
            IList<Subject> _subjectModels = UnitOfWork.Subjects.GetAll();
            foreach(Subject _subjectModel in _subjectModels)
            {
                Subjects.Add(Mapper.Map<SubjectDto>(_subjectModel));
            }            
        }

        private void OnSelect(object value)
        {
            // get selected subject id
            NewTest.SubjectId = int.Parse(value.ToString());

            // create new test            
            NewTest.Name = NewTestName;
            NewTestId = UnitOfWork.Tests.Add(NewTest);

            // navigate to next page
            NavManager.NavigateTo($"/testcategory/{NewTestId}");

        }

        private void OnClick()
        {
            // navigate to next page
            NavManager.NavigateTo($"/subject/create/{NewTestName}");
        }
    }
}
