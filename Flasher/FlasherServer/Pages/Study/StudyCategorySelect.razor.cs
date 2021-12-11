using AutoMapper;
using FlasherData.DataModels;
using FlasherData.Repositories.Interfaces;
using FlasherServer.Data.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;

namespace FlasherServer.Pages.Study
{
    public partial class StudyCategorySelect
    {
        [Inject]
        private IUnitOfWork UnitOfWork { get; set; }
        [Inject]
        private IMapper Mapper { get; set; }
        [Inject]
        private NavigationManager NavManager { get; set; }
        [Parameter]
        public string selectedsubjectid { get; set; }
        private int SelectedSubjectId { get; set; }
        private Category SelectedCategory { get; set; } = new Category();

        private List<int> SelectedCategoryIds { get; set; } = new List<int>();
        private Dictionary<string, string> SubjectAndCategories { get; set; } = new Dictionary<string, string>();
        private List<Category> Categories { get; set; } = new List<Category>();

        
        protected override void OnInitialized()
        {
            // get url parameters
            SelectedSubjectId = Int32.Parse(selectedsubjectid);

            // get categories form subject
            List<CategoryDm> _categoryDms = UnitOfWork.CategoryDms.Where(s => s.SubjectId == SelectedSubjectId).ToList();
            foreach (CategoryDm _categoryDm in _categoryDms)
            {
                Categories.Add(Mapper.Map<Category>(_categoryDm));
            }
            
        }

        private void CheckboxClicked(int? categoryId, object checkedValue)
        {
            int _categoryId = (int)categoryId;
            if ((bool)checkedValue)
            {
                if (!SelectedCategoryIds.Contains(_categoryId))
                {
                    SelectedCategoryIds.Add(_categoryId);
                }
            }
            else
            {
                if (SelectedCategoryIds.Contains(_categoryId))
                {
                    SelectedCategoryIds.Remove(_categoryId);
                }
            }
        }

        private void HandleOnValidSubmit()
        {
            SubjectAndCategories.Add("Subject", $"{SelectedSubjectId}");
            foreach (int i in SelectedCategoryIds)
            {
                SubjectAndCategories.Add($"Category{i}", $"{i}");
            }
            NavManager.NavigateTo(QueryHelpers.AddQueryString("/studyflashcards", SubjectAndCategories));
        }
    }
}
