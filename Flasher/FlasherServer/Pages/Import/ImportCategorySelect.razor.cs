using AutoMapper;
using FlasherData.DataModels;
using FlasherData.Repositories.Interfaces;
using FlasherServer.Data.Dtos;
using FlasherServer.Pages.Import.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherServer.Pages.Import
{
    public partial class ImportCategorySelect
    {
        ImportCategorySelectPage Page { get; set; } = new ImportCategorySelectPage();
        [Inject]
        private IUnitOfWork UnitOfWork { get; set; }
        [Inject]
        private IMapper Mapper { get; set; }
        [Inject]
        private NavigationManager NavManager { get; set; }
        private IList<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        [Parameter]
        public string selectedsubjectid { get; set; }
        private int SelectedSubjectId { get; set; }
        private int SelectedCategoryId { get; set; }

        protected override void OnInitialized()
        {
            // get url parameters
            SelectedSubjectId = Int32.Parse(selectedsubjectid);

            // get categories form subject
            List<Category> _categories = UnitOfWork.Categorys.Where(s => s.SubjectId == SelectedSubjectId).ToList();
            foreach (Category _category in _categories)
            {
                Categories.Add(Mapper.Map<CategoryDto>(_category));
            }

        }
        private void CheckboxClicked(int? categoryId, object checkedValue)
        {            
            if ((bool)checkedValue)
            {
                SelectedCategoryId = (int)categoryId;
            }
            else
            {
                SelectedCategoryId = 0;
            }
        }
        private void OnValidSubmit()
        {            
            NavManager.NavigateTo($"/importcards/{SelectedSubjectId}/{SelectedCategoryId}");
        }
    }
}
