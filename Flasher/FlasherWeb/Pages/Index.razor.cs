using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlasherWeb.Services.Models;
using FlasherWeb.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using FlasherWeb.Pages.Models;

namespace FlasherWeb.Pages
{
    public partial class Index
    {
        [Inject]
        private ISubjectService SubjectService { get; set; }
        [Inject]
        private ICategoryService SetService { get; set; }
        [Inject]
        private IFlashCardService FlashCardService { get; set; }
        private IndexPage IndexPage { get; set; } = new IndexPage();

        protected override async Task OnInitializedAsync()
        {
            IndexPage.Subjects = await SubjectService.GetAll();
            IndexPage.Categories = await SetService.GetAll();
            IndexPage.FlashCards = await FlashCardService.GetAll();
            IndexPage.Flashcard = IndexPage.FlashCards[IndexPage.CardIndex];

            IndexPage.Body = IndexPage.Flashcard.Front;
            IndexPage.Title = IndexPage.Flashcard.Title;
            IndexPage.SubjectTitle = IndexPage.Subjects.Where(ss => ss.Id == IndexPage.Flashcard.SubjectId).FirstOrDefault().Title;
            if (IndexPage.Flashcard.CategoryId is not null && IndexPage.Flashcard.CategoryId != 0)
            {
                IndexPage.CategoryTitle = IndexPage.Categories.Where(s => s.Id == IndexPage.Flashcard.CategoryId).FirstOrDefault().Title;
            }
            IndexPage.AnsweredCorrectly = IndexPage.Flashcard.AnsweredCorrectly;          
        }

        private void NextFlashCard()
        {
            if (IndexPage.CardIndex < IndexPage.FlashCards.Count - 1)
            {
                if (IndexPage.CardIndex != IndexPage.FlashCards.Count - 1)
                {
                    IndexPage.CardIndex = FindNextIndex(IndexPage.CardIndex);
                    IndexPage.Flashcard = IndexPage.FlashCards[IndexPage.CardIndex];
                    IndexPage.SubjectTitle = IndexPage.Subjects.Where(ss => ss.Id == IndexPage.Flashcard.SubjectId).FirstOrDefault().Title;
                    IndexPage.CategoryTitle = IndexPage.Categories.Where(s => s.Id == IndexPage.Flashcard.CategoryId).FirstOrDefault().Title;
                }
                SetFlashCardFront();
            }
            IndexPage.Counter++;
        }

        private void LastFlashCard()
        {
            if (IndexPage.CardIndex >= 0 )
            {
                if (IndexPage.CardIndex != 0)
                {
                    IndexPage.CardIndex = FindPreviousIndex(IndexPage.CardIndex);
                    IndexPage.Flashcard = IndexPage.FlashCards[IndexPage.CardIndex];                        
                }
                SetFlashCardFront();
            }
        }

        // Finds index of next Flashcard in FlashCards list that has not been answered correctly (has AnsweredCorrectly == false)
        private int FindNextIndex(int currentIndex)
        {
            // finds the index of the last incorrect answer (AnsweredCorrectly == false)
            int _lastIncorrectAnswerIndex = -100;
            if (IndexPage.FlashCards[currentIndex].AnsweredCorrectly == false)
            {
                _lastIncorrectAnswerIndex = currentIndex; 
            }
            else
            {
                int x = currentIndex;
                while (_lastIncorrectAnswerIndex == -100 && x > 0) 
                {
                    if (IndexPage.FlashCards[x].AnsweredCorrectly == false)
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
            while ( i <= IndexPage.FlashCards.Count - 1)
            {
                if (i != currentIndex && IndexPage.FlashCards[i].AnsweredCorrectly == false)
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
            if (IndexPage.FlashCards[currentIndex].AnsweredCorrectly == false)
            {
                _latestIncorrectAnswerIndex = currentIndex;
            }
            else
            {
                int x = currentIndex;
                while (_latestIncorrectAnswerIndex == -100 && x < IndexPage.FlashCards.Count - 1)
                {
                    if (IndexPage.FlashCards[x].AnsweredCorrectly == false)
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
                if (i != currentIndex && IndexPage.FlashCards[i].AnsweredCorrectly == false)
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
            IndexPage.Front = !IndexPage.Front;
            if (IndexPage.Front == true)
            {
                SetFlashCardFront();                
            }
            else
            {
                SetFlashCardBack();
            }
        }

        private async void UpdateAnswerStatus()
        {
            IndexPage.AnsweredCorrectly = !IndexPage.AnsweredCorrectly;
            IndexPage.Flashcard.AnsweredCorrectly = IndexPage.AnsweredCorrectly;
            await FlashCardService.Update(IndexPage.Flashcard);
        }

        private void SetFlashCardFront()
        {

            IndexPage.Title = IndexPage.Flashcard.Title;
            IndexPage.Body = IndexPage.Flashcard.Front;
            IndexPage.AnsweredCorrectly = IndexPage.Flashcard.AnsweredCorrectly;
            IndexPage.Side = "Front";
            IndexPage.ShowButton = "Back";
        }

        private void SetFlashCardBack()
        {

            IndexPage.Title = IndexPage.Flashcard.Title;
            IndexPage.Body = IndexPage.Flashcard.Back;
            IndexPage.AnsweredCorrectly = IndexPage.Flashcard.AnsweredCorrectly;
            IndexPage.Side = "Back";
            IndexPage.ShowButton = "Front";
        }

        private void LoadSubjectCategories()
        {
            IndexPage.SelectedCategories = IndexPage.Categories.Where(s => s.SubjectId == IndexPage.SelectedSubjectId).ToList();            
        }

        private void LoadCategoryFlashCards()
        {
            throw new NotImplementedException("LoadCategoryFlashCards has not yet be implmemented");
        }

        private void Submit()
        {    
            //TODO: create submit action if needed.
            //throw new NotImplementedException("Submit has not yet be implmemented");
        }



    }
}
