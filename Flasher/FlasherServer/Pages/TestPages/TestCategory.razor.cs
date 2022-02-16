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

namespace FlasherServer.Pages.TestPages
{
    public partial class TestCategory
    {
        [Inject]
        private IUnitOfWork UnitOfWork { get; set; }
        [Inject]
        private IMapper Mapper { get; set; }
        [Inject]
        private NavigationManager NavManager { get; set; }
        [Parameter]        
        public int TestId { get; set; }
       
        private int SubjectId { get; set; }
        private CategoryDto SelectedCategory { get; set; } = new CategoryDto();
        private List<int> SelectedCategoryIds { get; set; } = new List<int>();
        private Dictionary<string, string> SelectedCategoriesDict { get; set; } = new Dictionary<string, string>();
        private List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

        
        protected override void OnInitialized()
        {
            // initialize page data
            
            // get test
            Test Test = UnitOfWork.Tests.Get(TestId);

            // get categories from subject
            SubjectId = Test.SubjectId;            
            List<Category> _categories = UnitOfWork.Categories.Where(s => s.SubjectId == SubjectId).ToList();
            if (_categories is not null && _categories.Count > 0) 
            {
                foreach (Category _category in _categories)
                {
                    Categories.Add(Mapper.Map<CategoryDto>(_category));
                }
            }
        }

        private void CheckboxClicked(int? categoryId, object checkedValue)
        {
            // adds a category to list if it is checked, removes the category is unchecked
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

        private void OnValidSubmit()
        {

            foreach (int i in SelectedCategoryIds)
            {
                SelectedCategoriesDict.Add($"Category{i}", $"{i}");
            }
            NavManager.NavigateTo(QueryHelpers.AddQueryString($"/testquestion/{TestId}", SelectedCategoriesDict));

            //NavManager.NavigateTo($"/testquestion/{TestId}");
        }

        private void AddCategory()
        {
            NavManager.NavigateTo($"/category/create/{TestId}");
        }
    }
}
