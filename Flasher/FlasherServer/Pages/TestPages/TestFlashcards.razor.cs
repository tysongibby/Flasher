using AutoMapper;
using FlasherData.Context;
using FlasherData.DataModels;
using FlasherData.Repositories.Interfaces;
using FlasherServer.Data.Dtos;
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

        // Study category of the flashcard currently being displayed
        private List<CategoryDto> CategoryDtos { get; set; } = new List<CategoryDto>();

        // Flashcard currently being displayed
        private FlashcardDto FlashcardDto { get; set; } = new FlashcardDto();

        List<FlashcardDto> FlashcardDtos { get; set; } = new List<FlashcardDto>();

        // List of flashcards for this study session
        private List<QuestionDto> QuestionDtos { get; set; } = new List<QuestionDto>();

        // Index used to track which flashcard item in the Flashcards list being displayed
        private int CardIndex { get; set; } = 0;

        // true if text from front of flashcard (question) is being displayed and
        // false if it is the back (answer) of the flashcard being displayed
        private bool IsFront { get; set; } = true;

        // Stores the text to inform to the user which side of the flashcard is being shown
        private string CardSide { get; set; } = "Front";

        // Stores the display text for the Name of the current flashcard
        private string CardName { get; set; } = string.Empty;

        // Stores the display text for the front of back of the current flashcard
        private string CardBody { get; set; } = string.Empty;

        // Stores the display text for the Subject Name of the current flashcard
        private string SubjectName { get; set; } = string.Empty;

        // Stores the display text for the Category Name of the current flashcard
        private string CategoryName { get; set; } = string.Empty;

        // Stores the display text for the button that allows the user to "flip" the card
        private string ShowButton { get; set; } = "Back";

        // Allows user to track if they answered a flashcard correctly or not,
        // true for answered correctly and false for not answered corretly yet
        private bool AnsweredCorrectly { get; set; } = false;

        private int Counter { get; set; } = 0; //TEMP property until list object features are implemented
        
        private TestFlashcardsPage Page { get; set; } = new TestFlashcardsPage();


        protected override void OnInitialized()
        {
            
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
            
            // convert flashcard data model to dto
            foreach (Flashcard flashcard in Flashcards)
            {                
                FlashcardDtos.Add(Mapper.Map<FlashcardDto>(flashcard));
            }
            // get Flashcard to be displayed on page
            FlashcardDto = Mapper.Map<FlashcardDto>(Flashcards[CardIndex]);

            // set data to be displayed on page
            CardBody = FlashcardDto.Front;
            CardName = FlashcardDto.Name;
            SubjectName = Subject.Name;
            Question = FlashcardDto.Questions.Where(q => q.TestId == TestId).FirstOrDefault();
            if (FlashcardDto.CategoryId is not null && FlashcardDto.CategoryId != 0)
            {
                CategoryName = UnitOfWork.Categories.Where(s => s.Id == FlashcardDto.CategoryId).FirstOrDefault().Name;
            }            
        }

        // set flashcard index next flashcard in sequence that has not already been answered correctly
        private void NextFlashcard()
        {
            if (CardIndex < FlashcardDtos.Count - 1)
            {
                if (CardIndex != FlashcardDtos.Count - 1)
                {
                    CardIndex = FindNextIndex(CardIndex);
                    FlashcardDto = FlashcardDtos[CardIndex];
                    SubjectName = Subject.Name;
                    CategoryName = Categories.Where(s => s.Id == FlashcardDto.CategoryId).FirstOrDefault().Name;
                    Question = FlashcardDtos[CardIndex].Questions.Where(q => q.TestId == TestId).FirstOrDefault();
                    // TODO: make sure a test can only have only one of each flashcard i.e. a flashcard can be related
                    // via FK to multiple questions but each one of those questions must be from a different Test
                }
                SetFlashcardFront();
            }
            Counter++;
        }

        // set flashcard index to previous flashcard in sequence that has not been answered correctly
        private void LastFlashcard()
        {
            if (CardIndex >= 0)
            {
                if (CardIndex != 0)
                {
                    CardIndex = FindPreviousIndex(CardIndex);                    
                }
                SetFlashcardFront();
            }
        }

        // Finds index of next Flashcard in Flashcards list that has not been answered correctly (has AnsweredCorrectly == false)
        private int FindNextIndex(int currentIndex)
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
            while (i <= FlashcardDtos.Count - 1)
            {
                Question _question = FlashcardDtos[i].Questions.Where(q => q.TestId == TestId).FirstOrDefault();
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
                while (_latestIncorrectAnswerIndex == -100 && x < FlashcardDtos.Count - 1)
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
            IsFront = !IsFront;
            if (IsFront == true)
            {
                SetFlashcardFront();
            }
            else
            {
                SetFlashcardBack();
            }
        }

        // save answer correctly status to database
        private void UpdateAnswerStatus()
        {
            AnsweredCorrectly = !AnsweredCorrectly;            
            int pk = UnitOfWork.Flashcards.Update(Mapper.Map<Flashcard>(FlashcardDto));
        }

        // sets content of page to flashcard front data
        private void SetFlashcardFront()
        {

            CardName = FlashcardDto.Name;
            CardBody = FlashcardDto.Front;            
            CardSide = "Front";
            ShowButton = "Back";
        }

        // sets content of page to flashcard back data
        private void SetFlashcardBack()
        {

            CardName = FlashcardDto.Name;
            CardBody = FlashcardDto.Back;            
            CardSide = "Back";
            ShowButton = "Front";
        }

        //private void CategorySelectedSubject(int id)
        //{
        //    throw new NotImplementedException("SetSelectedSubject has not yet be implmemented");
        //}

        //private void LoadSubjectElements()
        //{
        //    throw new NotImplementedException("LoadSubjectElements has not yet be implmemented");
        //}

        //private void LoadSubjectCategories()
        //{
        //    SelectedCategories = Categories.Where(s => s.SubjectId == Subject.Id).ToList();
        //    Console.WriteLine($"Categories for Subject with Id of {Subject.Id} have been loaded.");
        //}

        //private void OnSelectedSubjectSelect(int id)
        //{
        //    SelectedCategoryId = id;
        //}

        //private void LoadCategoryFlashcards()
        //{
        //    throw new NotImplementedException("LoadCategoryFlashcards has not yet be implmemented");
        //}

        private void HandleOnSubmit()
        {
            //TODO: create submit action if needed.
            //throw new NotImplementedException("Submit has not yet be implmemented");
        }



    }
}

