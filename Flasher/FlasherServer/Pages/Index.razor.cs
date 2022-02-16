using FlasherData.Repositories.Interfaces;
using FlasherData.DataModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherServer.Pages
{
    public partial class Index
    {
        [Inject]
        private NavigationManager NavManager { get; set; }
        [Inject]
        private IUnitOfWork UnitOfWork { get; set; }

        protected override void OnInitialized()
        {
            List<Question> questions = UnitOfWork.Questions.GetAll().Where(q => q.TestId == 1).ToList();
            if (questions == null || questions.Count < 1)
            {
                List<Flashcard> flashcards = UnitOfWork.Flashcards.GetAllFlashcardsForSubject(1).ToList();
                questions = new List<Question>() { };
                int questionCount = 1;
                foreach (Flashcard flashcard in flashcards)
                {
                    Question question = new Question
                    {
                        Id = 0,
                        FlashcardId = flashcard.Id,
                        Number = questionCount,
                        AnsweredCorrectly = false,
                        TestId = 1
                    };
                    questions.Add(question);
                }
                UnitOfWork.Questions.AddRange(questions);
            }

        }

        public void ContinueTest()
        {
            NavManager.NavigateTo($"/continuetest");
        }

        public void NewTest()
        {
       
            NavManager.NavigateTo($"/testsubject");
        }
    }
}
