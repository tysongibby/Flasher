using AutoMapper;
using FlasherData.Context;
using FlasherData.DataModels;
using FlasherData.Repositories.Interfaces;
using FlasherServer.Pages.TestPages.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherServer.Pages.TestPages
{
    public partial class TestFlashcards
    {
        [Inject]
        private IUnitOfWork UnitOfWork { get; set; }
        [Inject]
        private IMapper Mapper { get; set; }
        [Inject]
        private NavigationManager NavManager { get; set; }


        [Parameter]
        public int TestId { get; set; }        

        private Test Test { get; set; }
        private List<Category> Categories { get; set; } = new List<Category>();
        List<Flashcard> Flashcards { get; set; } = new List<Flashcard>();
        private List<Question> Questions { get; set; } = new List<Question>();
        private Question Question { get; set; }

        // Study subject of the flashcard currently being displayed
        private Subject Subject { get; set; } = new Subject();       

        // Flashcard currently being displayed
        private Flashcard Flashcard { get; set; } = new Flashcard();
        
        // Index used to track which flashcard item in the Flashcards list being displayed
        private int QuestionIndex { get; set; } = 0;

        // true if text from front of flashcard (question) is being displayed and
        // false if it is the back (answer) of the flashcard being displayed
        private bool IsFront { get; set; } = true;

        // Allows user to track if they answered a flashcard correctly or not,
        // true for answered correctly and false for not answered corretly yet
        private bool AnsweredCorrectly { get; set; } = false;

        private int Counter { get; set; } = 0; //TEMP property until list object features are implemented
        
        private TestFlashcardsPage PageUi { get; set; } = new TestFlashcardsPage();


        protected override void OnInitialized()
        {
            PageUi.ShowButton = "Back";
            PageUi.CardSide = "Front";

            // get test
            Test = UnitOfWork.Tests.Get(TestId);
            
            // get test questions
            Questions = UnitOfWork.Questions.GetAll().Where(q => q.TestId == Test.Id).ToList();

            // get subject
            Subject = UnitOfWork.Subjects.Get(Test.SubjectId);

            // get test categories
            Categories = UnitOfWork.Categories.GetAll().Where(c => c.SubjectId == Test.SubjectId).ToList();

            // get test flashcards
            Flashcards = UnitOfWork.Flashcards.GetAll().Where(f => Categories.Contains(UnitOfWork.Categories.Get(f.CategoryId))).ToList();     
            
            // set data to be displayed on page
            Question = GetQuestion(true);
            Flashcard = Flashcards.Find(f => f.Id == Question.FlashcardId);
            PageUi.QuestionNumber = Question.Number;
            PageUi.CardBody = Flashcard.Front;
            PageUi.CardName = Flashcard.Name;
            PageUi.SubjectName = Subject.Name;
            //Question = Flashcard.Questions.Where(q => q.TestId == TestId).FirstOrDefault();
            if (Flashcard.CategoryId != 0)
            {
                PageUi.CategoryName = UnitOfWork.Categories.Where(s => s.Id == Flashcard.CategoryId).FirstOrDefault().Name;
            }            
        }

        // set flashcard information and increment question to next quetions in sequence that has not already been answered correctly
        private void GetNextQuestion()
        {
            Question = GetQuestion(true);            
        }

        // set flashcard index to previous flashcard in sequence that has not been answered correctly
        private void GetLastQuestion()
        {
            Question = GetQuestion(false);
        }

        /// <summary>
        /// Returns a question in the test question sequence: use true if next question is required or false if previous question is required
        /// </summary>
        /// <param name="next">true if next question is required or false if previous question is required</param>
        /// <returns>Question</returns>
        private Question GetQuestion(bool next)
        {
            Question question = new Question();
            if (Questions != null && Questions.Count > 0)
            {
                if (next)
                {
                    if (QuestionIndex < Questions.Count)
                    {
                        QuestionIndex++;
                    }
                    question = Questions[QuestionIndex];
                    return question;
                }
                else if (!next)
                {
                    if (QuestionIndex > 0)
                    {
                        QuestionIndex--;
                    }                    
                    question = Questions[QuestionIndex];
                    return question;
                }

            }
            return question;
        }

        // Finds index of next Flashcard in Flashcards list that has not been answered correctly (has AnsweredCorrectly == false)
        private int GetNextUnansweredQuestionIndex( int currentIndex)
        {
            // finds the index of the last incorrect answer (AnsweredCorrectly == false)
            int _lastIncorrectAnswerIndex = -100;
            if (Question.AnsweredCorrectly == false)
            {
                _lastIncorrectAnswerIndex = currentIndex;
            }
            else
            {
                int x = currentIndex;
                while (_lastIncorrectAnswerIndex == -100 && x > 0)
                {
                    if (Question.AnsweredCorrectly == false)
                    {
                        _lastIncorrectAnswerIndex = currentIndex;
                    }
                    else
                    {
                        x--;
                    }
                }
            }

            // returns the index of the next incorrect answer (AnsweredCorrectly == false)
            // if remaining answers are all correct (AnsweredCorrectly == true), _lastIncorrectAnswerIndex is returned
            int i = currentIndex;
            while (i <= Questions.Count - 1)
            {
                Question _question = Flashcards[i].Questions.Where(q => q.TestId == TestId).FirstOrDefault();
                if (i != currentIndex &&  _question.AnsweredCorrectly == false)
                {
                    return i;
                }
                else
                {
                    i++;
                }
            }
            return _lastIncorrectAnswerIndex;

        }

        // Finds index of previous Flashcard in Flashcards list that has not been answered correctly (has AnsweredCorrectly == false)
        private int FindPreviousIndex(int currentIndex)
        {
            // finds the index of the latest incorrect answer (AnsweredCorrectly == false)
            int _latestIncorrectAnswerIndex = -100;
            if (Question.AnsweredCorrectly == false)
            {
                _latestIncorrectAnswerIndex = currentIndex;
            }
            else
            {
                int x = currentIndex;
                while (_latestIncorrectAnswerIndex == -100 && x < Flashcards.Count - 1)
                {
                    if (Question.AnsweredCorrectly == false)
                    {
                        _latestIncorrectAnswerIndex = currentIndex;
                    }
                    else
                    {
                        x++;
                    }
                }
            }

            // returns the index of the previous incorrect answer (AnsweredCorrectly == false)
            // if previous answers are all correct (AnsweredCorrectly == true), _latestIncorrectAnswerIndex is returned
            int i = currentIndex;
            while (i >= 0)
            {
                if (i != currentIndex && Question.AnsweredCorrectly == false)
                {
                    return i;
                }
                else
                {
                    i--;
                }
            }
            return _latestIncorrectAnswerIndex;
        }

        // changes page contenct from flaschard front content to flashcard back content and vice versa
        private void FlipFlashcard()
        {
            ToggleIsFront();
            SetPageUi();
        }

        private void ToggleIsFront()
        {
            IsFront = !IsFront;
        }

        // if IsFront is true, sets content of page to flashcard front data
        // if IsFront is false, sets content of pate to flashcard back data
        private void SetPageUi()
        {
            PageUi.CardName = Flashcard.Name;
            if (IsFront) 
            {
                PageUi.CardBody = Flashcard.Front;
                PageUi.CardSide = "Front";
                PageUi.ShowButton = "Back";
            }
            else if (!IsFront)
            {
                PageUi.CardBody = Flashcard.Back;
                PageUi.CardSide = "Back";
                PageUi.ShowButton = "Front";
            }
        }

        // save answer correctly status to database
        private void UpdateAnswerStatus()
        {
            AnsweredCorrectly = !AnsweredCorrectly;
            int pk = UnitOfWork.Flashcards.Update(Flashcard);
        }

        private void HandleOnSubmit()
        {
            //TODO: create submit action if needed.
            //throw new NotImplementedException("Submit has not yet be implmemented");
        }

    }
}

