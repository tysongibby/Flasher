using FlasherData.Repositories.Interfaces;
using FlasherServer.Data.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using FlasherData.DataModels;
using Microsoft.AspNetCore.Components.Web;

namespace FlasherServer.Pages.Study
{
    public partial class Index
    {
        [Inject]
        private IUnitOfWork UnitOfWork { get; set; }
        [Inject]
        private IMapper Mapper { get; set; }
        [Inject]
        NavigationManager NavManager { get; set; }
        private IList<SubjectDto> Subjects { get; set; } = new List<SubjectDto>();
        private SubjectDto SelectedSubject { get; set; } = new SubjectDto();
        private int SelectedSubjectId { get; set; }
       

        protected override void OnInitialized()
        {
            IList<Subject> _subjectModels = UnitOfWork.Subjects.GetAll();
            foreach(Subject _subjectModel in _subjectModels)
            {
                Subjects.Add(Mapper.Map<SubjectDto>(_subjectModel));
            }            
        }

        private void OnValidSubmit(object value)
        {
            SelectedSubjectId = int.Parse(value.ToString());
            NavManager.NavigateTo($"/studycategoryselect/{SelectedSubjectId}");
        }
    }
}
