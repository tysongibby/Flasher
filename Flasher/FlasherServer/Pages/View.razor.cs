using AutoMapper;
using FlasherData.DataModels;
using FlasherData.Repositories.Interfaces;
using FlasherServer.Data.Dtos;
using FlasherServer.Pages.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherServer.Pages
{
    public partial class View
    {
        [Inject]
        private IUnitOfWork UnitOfWork { get; set; }
        [Inject]
        private IMapper Mapper { get; set; }
        [Parameter]
        public List<int> selectcategoryids { get; set; }
        private List<int> SelectedCategoryIds { get; set; }
        private ViewPage ViewPage { get; set; } = new ViewPage();


        protected override void OnInitialized()
        {
            SelectedCategoryIds = selectcategoryids;
            // get all Subjects from db
            List<SubjectDm> subjectDms = UnitOfWork.SubjectDms.GetAll().ToList();
            foreach (SubjectDm subjectDm in subjectDms)
            {
                // convert data model to dto
                ViewPage.Subjects.Add(Mapper.Map<Subject>(subjectDm));
            }
            // get all Categories from db
            IList<CategoryDm> categoryDms = UnitOfWork.CategoryDms.GetAll();
            foreach (CategoryDm categoryDm in categoryDms)
            {
                // convert data model to dto
                ViewPage.Categories.Add(Mapper.Map<Category>(categoryDm));
            }
            // get all Flashcards db
            IList<FlashcardDm> flashcardDms = UnitOfWork.FlashcardDms.GetAll();
            foreach (FlashcardDm flashcardDm in flashcardDms)
            {
                // convert data model to dto
                ViewPage.Flashcards.Add(Mapper.Map<Flashcard>(flashcardDm));
            }
            // get Flashcard to be displayed on page
            ViewPage.Flashcard = ViewPage.Flashcards[ViewPage.CardIndex];

            // set data to be displayed on page
            ViewPage.Body = ViewPage.Flashcard.Front;
            ViewPage.Title = ViewPage.Flashcard.Title;
            ViewPage.SubjectTitle = ViewPage.Subjects.Where(ss => ss.Id == ViewPage.Flashcard.SubjectId).FirstOrDefault().Title;
            if (ViewPage.Flashcard.CategoryId is not null && ViewPage.Flashcard.CategoryId != 0)
            {
                ViewPage.CategoryTitle = ViewPage.Categories.Where(s => s.Id == ViewPage.Flashcard.CategoryId).FirstOrDefault().Title;
            }
            ViewPage.AnsweredCorrectly = ViewPage.Flashcard.AnsweredCorrectly;
        }

        private void NextFlashcard()
        {
            if (ViewPage.CardIndex < ViewPage.Flashcards.Count - 1)
            {
                if (ViewPage.CardIndex != ViewPage.Flashcards.Count - 1)
                {
                    ViewPage.CardIndex = FindNextIndex(ViewPage.CardIndex);
                    ViewPage.Flashcard = ViewPage.Flashcards[ViewPage.CardIndex];
                    ViewPage.SubjectTitle = ViewPage.Subjects.Where(ss => ss.Id == ViewPage.Flashcard.SubjectId).FirstOrDefault().Title;
                    ViewPage.CategoryTitle = ViewPage.Categories.Where(s => s.Id == ViewPage.Flashcard.CategoryId).FirstOrDefault().Title;
                }
                SetFlashcardFront();
            }
            ViewPage.Counter++;
        }

        private void LastFlashcard()
        {
            if (ViewPage.CardIndex >= 0)
            {
                if (ViewPage.CardIndex != 0)
                {
                    ViewPage.CardIndex = FindPreviousIndex(ViewPage.CardIndex);
                    ViewPage.Flashcard = ViewPage.Flashcards[ViewPage.CardIndex];
                }
                SetFlashcardFront();
            }
        }

        // Finds index of next Flashcard in Flashcards list that has not been answered correctly (has AnsweredCorrectly == false)
        private int FindNextIndex(int currentIndex)
        {
            // finds the index of the last incorrect answer (AnsweredCorrectly == false)
            int _lastIncorrectAnswerIndex = -100;
            if (ViewPage.Flashcards[currentIndex].AnsweredCorrectly == false)
            {
                _lastIncorrectAnswerIndex = currentIndex;
            }
            else
            {
                int x = currentIndex;
                while (_lastIncorrectAnswerIndex == -100 && x > 0)
                {
                    if (ViewPage.Flashcards[x].AnsweredCorrectly == false)
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
            while (i <= ViewPage.Flashcards.Count - 1)
            {
                if (i != currentIndex && ViewPage.Flashcards[i].AnsweredCorrectly == false)
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
            if (ViewPage.Flashcards[currentIndex].AnsweredCorrectly == false)
            {
                _latestIncorrectAnswerIndex = currentIndex;
            }
            else
            {
                int x = currentIndex;
                while (_latestIncorrectAnswerIndex == -100 && x < ViewPage.Flashcards.Count - 1)
                {
                    if (ViewPage.Flashcards[x].AnsweredCorrectly == false)
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
                if (i != currentIndex && ViewPage.Flashcards[i].AnsweredCorrectly == false)
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
            ViewPage.Front = !ViewPage.Front;
            if (ViewPage.Front == true)
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
            ViewPage.AnsweredCorrectly = !ViewPage.AnsweredCorrectly;
            ViewPage.Flashcard.AnsweredCorrectly = ViewPage.AnsweredCorrectly;
            int pk = UnitOfWork.FlashcardDms.Update(Mapper.Map<FlashcardDm>(ViewPage.Flashcard));
        }

        private void SetFlashcardFront()
        {

            ViewPage.Title = ViewPage.Flashcard.Title;
            ViewPage.Body = ViewPage.Flashcard.Front;
            ViewPage.AnsweredCorrectly = ViewPage.Flashcard.AnsweredCorrectly;
            ViewPage.Side = "Front";
            ViewPage.ShowButton = "Back";
        }

        private void SetFlashcardBack()
        {

            ViewPage.Title = ViewPage.Flashcard.Title;
            ViewPage.Body = ViewPage.Flashcard.Back;
            ViewPage.AnsweredCorrectly = ViewPage.Flashcard.AnsweredCorrectly;
            ViewPage.Side = "Back";
            ViewPage.ShowButton = "Front";
        }

        private void CategorySelectedSubject(int id)
        {
            throw new NotImplementedException("SetSelectedSubject has not yet be implmemented");
        }

        private void LoadSubjectElements()
        {
            throw new NotImplementedException("LoadSubjectElements has not yet be implmemented");
        }

        private void LoadSubjectCategories()
        {
            ViewPage.SelectedCategories = ViewPage.Categories.Where(s => s.SubjectId == ViewPage.SelectedSubjectId).ToList();
            Console.WriteLine($"Categories for Subject with Id of {ViewPage.SelectedSubjectId} have been loaded.");
        }

        private void OnSelectedSubjectSelect(int id)
        {
            ViewPage.SelectedCategoryId = id;
        }

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

