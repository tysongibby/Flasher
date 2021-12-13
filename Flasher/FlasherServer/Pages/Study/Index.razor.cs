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
            IList<SubjectDm> _subjectDmModels = UnitOfWork.SubjectDms.GetAll();
            foreach(SubjectDm _subjectDmModel in _subjectDmModels)
            {
                Subjects.Add(Mapper.Map<SubjectDto>(_subjectDmModel));
            }            
        }

        private void HandleOnValidSubmit()
        {
            NavManager.NavigateTo($"/studycategoryselect/{SelectedSubjectId}");
        }
    }
}
