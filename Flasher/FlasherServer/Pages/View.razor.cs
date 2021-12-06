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
            // get all FlashCards db
            IList<FlashCardDm> flashCardDms = UnitOfWork.FlashCardDms.GetAll();
            foreach (FlashCardDm flashCardDm in flashCardDms)
            {
                // convert data model to dto
                ViewPage.FlashCards.Add(Mapper.Map<Flashcard>(flashCardDm));
            }
            // get Flashcard to be displayed on page
            ViewPage.Flashcard = ViewPage.FlashCards[ViewPage.CardIndex];

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

        private void NextFlashCard()
        {
            if (ViewPage.CardIndex < ViewPage.FlashCards.Count - 1)
            {
                if (ViewPage.CardIndex != ViewPage.FlashCards.Count - 1)
                {
                    ViewPage.CardIndex = FindNextIndex(ViewPage.CardIndex);
                    ViewPage.Flashcard = ViewPage.FlashCards[ViewPage.CardIndex];
                    ViewPage.SubjectTitle = ViewPage.Subjects.Where(ss => ss.Id == ViewPage.Flashcard.SubjectId).FirstOrDefault().Title;
                    ViewPage.CategoryTitle = ViewPage.Categories.Where(s => s.Id == ViewPage.Flashcard.CategoryId).FirstOrDefault().Title;
                }
                SetFlashCardFront();
            }
            ViewPage.Counter++;
        }

        private void LastFlashCard()
        {
            if (ViewPage.CardIndex >= 0)
            {
                if (ViewPage.CardIndex != 0)
                {
                    ViewPage.CardIndex = FindPreviousIndex(ViewPage.CardIndex);
                    ViewPage.Flashcard = ViewPage.FlashCards[ViewPage.CardIndex];
                }
                SetFlashCardFront();
            }
        }

        // Finds index of next Flashcard in FlashCards list that has not been answered correctly (has AnsweredCorrectly == false)
        private int FindNextIndex(int currentIndex)
        {
            // finds the index of the last incorrect answer (AnsweredCorrectly == false)
            int _lastIncorrectAnswerIndex = -100;
            if (ViewPage.FlashCards[currentIndex].AnsweredCorrectly == false)
            {
                _lastIncorrectAnswerIndex = currentIndex;
            }
            else
            {
                int x = currentIndex;
                while (_lastIncorrectAnswerIndex == -100 && x > 0)
                {
                    if (ViewPage.FlashCards[x].AnsweredCorrectly == false)
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
            while (i <= ViewPage.FlashCards.Count - 1)
            {
                if (i != currentIndex && ViewPage.FlashCards[i].AnsweredCorrectly == false)
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

        // Finds index of previous Flashcard in FlashCards list that has not been answered correctly (has AnsweredCorrectly == false)
        private int FindPreviousIndex(int currentIndex)
        {
            // finds the index of the latest incorrect answer (AnsweredCorrectly == false)
            int _latestIncorrectAnswerIndex = -100;
            if (ViewPage.FlashCards[currentIndex].AnsweredCorrectly == false)
            {
                _latestIncorrectAnswerIndex = currentIndex;
            }
            else
            {
                int x = currentIndex;
                while (_latestIncorrectAnswerIndex == -100 && x < ViewPage.FlashCards.Count - 1)
                {
                    if (ViewPage.FlashCards[x].AnsweredCorrectly == false)
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
                if (i != currentIndex && ViewPage.FlashCards[i].AnsweredCorrectly == false)
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

        private void FlipFlashCard()
        {
            ViewPage.Front = !ViewPage.Front;
            if (ViewPage.Front == true)
            {
                SetFlashCardFront();
            }
            else
            {
                SetFlashCardBack();
            }
        }

        private void UpdateAnswerStatus()
        {
            ViewPage.AnsweredCorrectly = !ViewPage.AnsweredCorrectly;
            ViewPage.Flashcard.AnsweredCorrectly = ViewPage.AnsweredCorrectly;
            int pk = UnitOfWork.FlashCardDms.Update(Mapper.Map<FlashCardDm>(ViewPage.Flashcard));
        }

        private void SetFlashCardFront()
        {

            ViewPage.Title = ViewPage.Flashcard.Title;
            ViewPage.Body = ViewPage.Flashcard.Front;
            ViewPage.AnsweredCorrectly = ViewPage.Flashcard.AnsweredCorrectly;
            ViewPage.Side = "Front";
            ViewPage.ShowButton = "Back";
        }

        private void SetFlashCardBack()
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

        private void LoadCategoryFlashCards()
        {
            throw new NotImplementedException("LoadCategoryFlashCards has not yet be implmemented");
        }

        private void HandleOnSubmit()
        {
            //TODO: create submit action if needed.
            //throw new NotImplementedException("Submit has not yet be implmemented");
        }



    }
}

