using AutoMapper;
using FlasherData.DataModels;
using FlasherData.Repositories.Interfaces;
using FlasherServer.Data.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherServer.Pages.FlashcardPages
{
    public partial class Flashcard_Create
    {
        [Inject]
        private IUnitOfWork UnitOfWork { get; set; }
        [Inject]
        private NavigationManager NavManager { get; set; }
        [Inject]
        private IMapper Mapper { get; set; }

        [Parameter]
        public int TestId {get; set;}
        [Parameter]
        public int CategoryId { get; set; }


        private Test Test { get; set; }
        private Subject Subject { get; set; }
        private Category Category { get; set; }
        private string FrontText { get; set; }
        private int FrontTextAreaRows { get; set; }
        private string BackText { get; set; }
        private int BackTextAreaRows { get; set; }
        private FlashcardDto FlashcardDto { get; set; } = new FlashcardDto();   
        private Uri Uri { get; set; }

        protected override void OnInitialized()
        {
            Test = UnitOfWork.Tests.Get(TestId);
            Subject = UnitOfWork.Subjects.Get(Test.SubjectId);
            Category = UnitOfWork.Categories.Get(CategoryId);
            Uri = new Uri(NavManager.Uri);
        }


        private void CreateFlashcard()
        {
            // create flashcard
            FlashcardDto.Id = 0;
            FlashcardDto.CategoryId = CategoryId;
            Flashcard flashcard = Mapper.Map<Flashcard>(FlashcardDto);
            UnitOfWork.Flashcards.Add(flashcard);

            // navigate to next page
            NavManager.NavigateTo($"/testquestion/{Test.Id}{Uri.Query}");
        }


    }
}
