using FlasherServer.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherServer.Pages.TestPages.Models
{
    public class TestFlashcardsPage
    {
        public FlashcardDto Flashcard { get; set; } = new FlashcardDto();
        public List<FlashcardDto> Flashcards { get; set; } = new List<FlashcardDto>();
        public int CardIndex { get; set; } = 0;
        public bool Front { get; set; } = true;
        public string Side { get; set; } = "Front";
        public string Name { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string SubjectName { get; set; } = string.Empty;
        public SubjectDto Subject { get; set; } = new SubjectDto();
        public string CategoryName { get; set; } = string.Empty;
        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        public string ShowButton { get; set; } = "Back";
        public bool AnsweredCorrectly { get; set; } = false;

        public int Counter { get; set; } = 0; //TEMP property until list object features are implemented

    }
}
