using FlasherData.Repositories.Interfaces;
using FlasherServer.Data.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using FlasherData.DataModels;
using Microsoft.AspNetCore.Components.Web;

namespace FlasherServer.Pages
{
    public partial class Index
    {
        [Inject]
        private IUnitOfWork UnitOfWork { get; set; }
        [Inject]
        private IMapper Mapper { get; set; }
        [Inject]
        NavigationManager NavManager { get; set; }
        private IList<Subject> Subjects { get; set; } = new List<Subject>();
        private Subject SelectedSubject { get; set; } = new Subject();
        private int SelectedSubjectId { get; set; }
       

        protected override void OnInitialized()
        {
            IList<SubjectDm> _subjectDmModels = UnitOfWork.SubjectDms.GetAll();
            foreach(SubjectDm _subjectDmModel in _subjectDmModels)
            {
                Subjects.Add(Mapper.Map<Subject>(_subjectDmModel));
            }            
        }

        private void HandleOnValidSubmit()
        {
            NavManager.NavigateTo($"/categoryselect/{SelectedSubjectId}");
        }
    }
}
