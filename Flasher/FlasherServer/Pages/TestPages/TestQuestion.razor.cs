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
using FlasherServer.Pages.TestPages.Models;
using Microsoft.Extensions.Primitives;

namespace FlasherServer.Pages.TestPages
{
    public partial class TestQuestion
    {
        [Inject]
        private IUnitOfWork UnitOfWork { get; set; }
        [Inject]
        private IMapper Mapper { get; set; }
        [Inject]
        private NavigationManager NavManager { get; set; }
        [Parameter]
        public int TestId { get; set; }

        private TestQuestionPage Page { get; set; } = new TestQuestionPage();
        private int SubjectId { get; set; }
        private CategoryDto SelectedCategory { get; set; } = new CategoryDto();
        private List<int> SelectedCategoryIds { get; set; } = new List<int>();
        private Dictionary<string, string> CategoryDictionary { get; set; } = new Dictionary<string, string>();
        private List<CategoryDto> CategoryDtos { get; set; } = new List<CategoryDto>();

        private Uri Uri { get; set; }


        protected override void OnInitialized()
        {
            // Initialize page data

            // get test
            Test Test = UnitOfWork.Tests.Get(TestId);

            // get page uri (including query string)
            Uri = new Uri(NavManager.Uri);
            // get categories from querystring
            var categories = QueryHelpers.ParseQuery(Uri.Query);
            if (categories is not null && categories.Count > 0)
            {
                foreach (KeyValuePair<string, StringValues> pair in categories)
                {                 
                    {
                        // convert category from string value to int
                        int categoryId = Int32.Parse(pair.Value);
                        // get Category Data Model and map to Category Dto
                        CategoryDtos.Add(Mapper.Map<CategoryDto>(UnitOfWork.Categories.Get(categoryId)));
                    }
                }
            }
        }



        private void OnValidSubmit()
        {
            // create questions from each test category
            List<Question> questions = new List<Question>();
            int index = 1;            
            foreach (CategoryDto categoryDto in CategoryDtos)
            {
                List<Flashcard> flashcards = UnitOfWork.Flashcards.GetAllFlashcardsForCategory((int)categoryDto.Id).ToList();
                if (flashcards != null && flashcards.Count > 0)
                {
                    foreach (Flashcard flashcard in flashcards)
                    {
                        Question question = new Question
                        {
                            Id = 0,
                            FlashcardId = flashcard.Id,
                            AnsweredCorrectly = false,
                            Number = index,
                            TestId = TestId
                        };
                        questions.Add(question);
                        index++;
                    }
                }
            }
        }

        private void AddQuestions(int? categoryId)
        {            
            NavManager.NavigateTo($"/flashcard/create/{TestId}/{categoryId}{Uri.Query}");
        }


    }
}

