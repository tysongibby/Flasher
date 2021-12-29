using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;
using FlasherServer.Pages.Import.Models;
using FlasherServer.Data.Dtos;
using FlasherData.Repositories.Interfaces;
using AutoMapper;
using FlasherData.DataModels;

namespace FlasherServer.Pages.Import
{
    public partial class ImportSubjectSelect
    {
        [Inject]
        IUnitOfWork UnitOfWork { get; set; }
        [Inject]
        private IMapper Mapper { get; set; }
        [Inject]
        NavigationManager NavManager { get; set; }

        private ImportSubjectSelectPage Page { get; set; } = new ImportSubjectSelectPage();
        public int SelectedSubjectId { get; set; }
        private IList<SubjectDto> Subjects { get; set; } = new List<SubjectDto>();

        protected override void OnInitialized()
        {
            // get subjects
            List<Subject> _subjects = UnitOfWork.Subjects.GetAll().ToList();
            foreach (Subject _subject in _subjects)
            {
                Subjects.Add(Mapper.Map<SubjectDto>(_subject));
            }
            

        }

        public void OnValidSubmit()
        {
            NavManager.NavigateTo($"/importcategoryselect/{SelectedSubjectId}");
        }



    }
}

