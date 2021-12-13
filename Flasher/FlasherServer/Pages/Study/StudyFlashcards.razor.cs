using AutoMapper;
using FlasherData.Context;
using FlasherData.DataModels;
using FlasherData.Repositories.Interfaces;
using FlasherServer.Data.Dtos;
using FlasherServer.Pages.Study.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherServer.Pages.Study
{
    public partial class StudyFlashcards
    {
        [Inject]
        private IUnitOfWork UnitOfWork { get; set; }
        [Inject]
        private IMapper Mapper { get; set; }
        [Inject]        
        private NavigationManager NavManager { get; set; }
        
        // Study subject of the flashcard currently being displayed
        public SubjectDto Subject { get; set; } = new SubjectDto();

        // Study category of the flashcard currently being displayed
        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

        // Flashcard currently being displayed
        public FlashcardDto Flashcard { get; set; } = new FlashcardDto();               

        // List of flashcards for this study session
        public List<FlashcardDto> Flashcards { get; set; } = new List<FlashcardDto>();

        // Index used to track which flashcard item in the Flashcards list being displayed
        public int CardIndex { get; set; } = 0;

        // true if text from front of flashcard (question) is being displayed and
        // false if it is the back (answer) of the flashcard being displayed
        public bool IsFront { get; set; } = true;

        // Stores the text to inform to the user which side of the flashcard is being shown
        public string CardSide { get; set; } = "Front";

        // Stores the display text for the Title of the current flashcard
        public string CardTitle { get; set; } = string.Empty;

        // Stores the display text for the front of back of the current flashcard
        public string CardBody { get; set; } = string.Empty;

        // Stores the display text for the Subject Title of the current flashcard
        public string SubjectTitle { get; set; } = string.Empty;

        // Stores the display text for the Category Title of the current flashcard
        public string CategoryTitle { get; set; } = string.Empty;

        // Stores the display text for the button that allows the user to "flip" the card
        public string ShowButton { get; set; } = "Back";

        // Allows user to track if they answered a flashcard correctly or not,
        // true for answered correctly and false for not answered corretly yet
        public bool AnsweredCorrectly { get; set; } = false;

        public int Counter { get; set; } = 0; //TEMP property until list object features are implemented
        
        private StudyFlashcardsPage Page { get; set; } = new StudyFlashcardsPage();


        protected override void OnInitialized()
        {
            // get page uri (including query string)
            Uri uri = new Uri(NavManager.Uri);

            // get query string from page uri
            var SubjectAndCategories = QueryHelpers.ParseQuery(uri.Query);            

            // get flashcard subject and categories from query string and add them to Page model         
            foreach(KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues> pair in SubjectAndCategories)
            {
                if (pair.Key == "Subject")
                {
                    // convert subject from string value to int
                    int SelectedSubjectId = Int32.Parse(pair.Value);                    
                    // get Subject Data Model and map to Subject Dto
                    Subject = (Mapper.Map<SubjectDto>(UnitOfWork.SubjectDms.Get(SelectedSubjectId)));
                }
                else
                {
                    // convert category from string value to int
                    int categoryId = Int32.Parse(pair.Value);
                    // get Category Data Model and map to Category Dto
                    Categories.Add(Mapper.Map<CategoryDto>(UnitOfWork.CategoryDms.Get(categoryId)));
                }                
            }
            // get all flashcards for a subject
            List<FlashcardDm> flashcardDms = UnitOfWork.FlashcardDms.GetAllFlashcardsForSubjectDm((int)Subject.Id).ToList() ;


            // convert flashcard data model to dto
            foreach (FlashcardDm flashcardDm in flashcardDms)
            {                
                Flashcards.Add(Mapper.Map<FlashcardDto>(flashcardDm));
            }
            // get Flashcard to be displayed on page
            Flashcard = Flashcards[CardIndex];

            // set data to be displayed on page
            CardBody = Flashcard.Front;
            CardTitle = Flashcard.Title;
            SubjectTitle = Subject.Title;
            if (Flashcard.CategoryId is not null && Flashcard.CategoryId != 0)
            {
                CategoryTitle = Categories.Where(s => s.Id == Flashcard.CategoryId).FirstOrDefault().Title;
            }
            AnsweredCorrectly = Flashcard.AnsweredCorrectly;
        }

        // set flashcard index next flashcard in sequence that has not already been answered correctly
        private void NextFlashcard()
        {
            if (CardIndex < Flashcards.Count - 1)
            {
                if (CardIndex != Flashcards.Count - 1)
                {
                    CardIndex = FindNextIndex(CardIndex);
                    Flashcard = Flashcards[CardIndex];
                    SubjectTitle = Subject.Title;                    
                    CategoryTitle = Categories.Where(s => s.Id == Flashcard.CategoryId).FirstOrDefault().Title;
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
                    Flashcard = Flashcards[CardIndex];
                }
                SetFlashcardFront();
            }
        }

        // Finds index of next Flashcard in Flashcards list that has not been answered correctly (has AnsweredCorrectly == false)
        private int FindNextIndex(int currentIndex)
        {
            // finds the index of the last incorrect answer (AnsweredCorrectly == false)
            int _lastIncorrectAnswerIndex = -100;
            if (Flashcards[currentIndex].AnsweredCorrectly == false)
            {
                _lastIncorrectAnswerIndex = currentIndex;
            }
            else
            {
                int x = currentIndex;
                while (_lastIncorrectAnswerIndex == -100 && x > 0)
                {
                    if (Flashcards[x].AnsweredCorrectly == false)
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
            while (i <= Flashcards.Count - 1)
            {
                if (i != currentIndex && Flashcards[i].AnsweredCorrectly == false)
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
            if (Flashcards[currentIndex].AnsweredCorrectly == false)
            {
                _latestIncorrectAnswerIndex = currentIndex;
            }
            else
            {
                int x = currentIndex;
                while (_latestIncorrectAnswerIndex == -100 && x < Flashcards.Count - 1)
                {
                    if (Flashcards[x].AnsweredCorrectly == false)
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
                if (i != currentIndex && Flashcards[i].AnsweredCorrectly == false)
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
            Flashcard.AnsweredCorrectly = AnsweredCorrectly;
            int pk = UnitOfWork.FlashcardDms.Update(Mapper.Map<FlashcardDm>(Flashcard));
        }

        // sets content of page to flashcard front data
        private void SetFlashcardFront()
        {

            CardTitle = Flashcard.Title;
            CardBody = Flashcard.Front;
            AnsweredCorrectly = Flashcard.AnsweredCorrectly;
            CardSide = "Front";
            ShowButton = "Back";
        }

        // sets content of page to flashcard back data
        private void SetFlashcardBack()
        {

            CardTitle = Flashcard.Title;
            CardBody = Flashcard.Back;
            AnsweredCorrectly = Flashcard.AnsweredCorrectly;
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

