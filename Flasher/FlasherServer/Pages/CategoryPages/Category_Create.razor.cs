using AutoMapper;
using FlasherData.Repositories.Interfaces;
using FlasherServer.Data.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlasherData.DataModels;

namespace FlasherServer.Pages.CategoryPages
{
    public partial class Category_Create
    {
        CategoryDto NewCategory = new CategoryDto();
        [Inject]
        NavigationManager NavManager { get; set; }
        [Inject]
        IUnitOfWork UnitOfWork { get; set; }
        [Inject]
        IMapper Mapper { get; set; }

        [Parameter]
        public int SubjectId { get; set; }

        private void OnValidSumbit()
        {
            NewCategory.Id = 0;
            NewCategory.SubjectId = SubjectId;
            Category _newCategory = Mapper.Map<Category>(NewCategory);
            int newCategoryId = UnitOfWork.Categories.Add(_newCategory);

            NavManager.NavigateTo($"/studyquestions/{SubjectId}/{newCategoryId}");
        }
    }
}
