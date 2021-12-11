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
        public Flashcard Flashcard { get; set; } = new Flashcard();
        public List<Flashcard> Flashcards { get; set; } = new List<Flashcard>();
        public int CardIndex { get; set; } = 0;
        public bool Front { get; set; } = true;
        public string Side { get; set; } = "Front";
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string SubjectTitle { get; set; } = string.Empty;
        public Subject Subject { get; set; } = new Subject();
        public string CategoryTitle { get; set; } = string.Empty;
        public List<Category> Categories { get; set; } = new List<Category>();
        public string ShowButton { get; set; } = "Back";
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
                    Subject = (Mapper.Map<Subject>(UnitOfWork.SubjectDms.Get(SelectedSubjectId)));
                }
                else
                {
                    // convert category from string value to int
                    int categoryId = Int32.Parse(pair.Value);
                    // get Category Data Model and map to Category Dto
                    Categories.Add(Mapper.Map<Category>(UnitOfWork.CategoryDms.Get(categoryId)));
                }                
            }
            // get flashcards for subject and categories
            List<FlashcardDm> flashcardDms = new List<FlashcardDm>();
            using (FlasherContext context = new FlasherContext())
            {
                for (int i = 0; i < Categories.Count; i++)
                {
                    List<FlashcardDm> _flashCards = (from categoryDm in context.CategoryDms
                                    join flashcardDm in context.FlashcardDms on categoryDm.Id equals flashcardDm.CategoryId
                                    where categoryDm.SubjectId == Subject.Id && categoryDm.Id == Categories[i].Id
                                    select flashcardDm).ToList();
                    flashcardDms.AddRange(_flashCards);
                }
            }
            foreach (FlashcardDm flashcardDm in flashcardDms)
            {
                // convert flascard data model to dto
                Flashcards.Add(Mapper.Map<Flashcard>(flashcardDm));
            }
            // get Flashcard to be displayed on page
            Flashcard = Flashcards[CardIndex];

            // set data to be displayed on page
            Body = Flashcard.Front;
            Title = Flashcard.Title;
            SubjectTitle = Subject.Title;
            if (Flashcard.CategoryId is not null && Flashcard.CategoryId != 0)
            {
                CategoryTitle = Categories.Where(s => s.Id == Flashcard.CategoryId).FirstOrDefault().Title;
            }
            AnsweredCorrectly = Flashcard.AnsweredCorrectly;
        }

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

        private void FlipFlashcard()
        {
            Front = !Front;
            if (Front == true)
            {
                SetFlashcardFront();
            }
            else
            {
                SetFlashcardBack();
            }
        }

        private void UpdateAnswerStatus()
        {
            AnsweredCorrectly = !AnsweredCorrectly;
            Flashcard.AnsweredCorrectly = AnsweredCorrectly;
            int pk = UnitOfWork.FlashcardDms.Update(Mapper.Map<FlashcardDm>(Flashcard));
        }

        private void SetFlashcardFront()
        {

            Title = Flashcard.Title;
            Body = Flashcard.Front;
            AnsweredCorrectly = Flashcard.AnsweredCorrectly;
            Side = "Front";
            ShowButton = "Back";
        }

        private void SetFlashcardBack()
        {

            Title = Flashcard.Title;
            Body = Flashcard.Back;
            AnsweredCorrectly = Flashcard.AnsweredCorrectly;
            Side = "Back";
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

        private void LoadCategoryFlashcards()
        {
            throw new NotImplementedException("LoadCategoryFlashcards has not yet be implmemented");
        }

        private void HandleOnSubmit()
        {
            //TODO: create submit action if needed.
            //throw new NotImplementedException("Submit has not yet be implmemented");
        }



    }
}

