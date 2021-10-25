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
        private ISupersetService SupersetService { get; set; }
        [Inject]
        private ISetService SetService { get; set; }
        [Inject]
        private IFlashCardService FlashCardService { get; set; }
        private IndexPage IndexPage { get; set; } = new IndexPage();
        //private List<FlashCard> FlashCards { get; set; } = new List<FlashCard>();
        //private FlashCard FlashCard { get; set; } = new FlashCard();
        //private int CardIndex { get; set; } = 0;
        //private bool Front { get; set; } = true;
        //private string Side { get; set; } = "Front";
        //private string Title { get; set; } = string.Empty;
        //private string Body { get; set; } = string.Empty;
        //private string SupersetTitle { get; set; } = string.Empty;
        //private List<Superset> Supersets { get; set; } = new List<Superset>();
        //private string SetTitle { get; set; } = string.Empty;
        //private List<Set> Sets { get; set; } = new List<Set>();
        //private string ShowButton { get; set; } = "Back";
        //private bool AnsweredCorrectly { get; set; } = false;        
        //private List<Set> SuperSetSelectElements { get; set; } = new List<Set>();
        //private List<Set> SelectedSets { get; set; } = new List<Set>();
        //private int SelectedSupersetId { get; set; } = 0;
        //private int SelectedSetId { get; set; } = 0;


        protected override async Task OnInitializedAsync()
        {
            IndexPage.Supersets = await SupersetService.GetAll();
            IndexPage.Sets = await SetService.GetAll();
            IndexPage.FlashCards = await FlashCardService.GetAll();
            IndexPage.FlashCard = IndexPage.FlashCards[IndexPage.CardIndex];

            IndexPage.Body = IndexPage.FlashCard.Front;
            IndexPage.Title = IndexPage.FlashCard.Title;
            IndexPage.SupersetTitle = IndexPage.Supersets.Where(ss => ss.Id == IndexPage.FlashCard.SuperSetId).FirstOrDefault().Title;
            if (IndexPage.FlashCard.SetId is not null && IndexPage.FlashCard.SetId != 0)
            {
                IndexPage.SetTitle = IndexPage.Sets.Where(s => s.Id == IndexPage.FlashCard.SetId).FirstOrDefault().Title;
            }
            IndexPage.AnsweredCorrectly = IndexPage.FlashCard.AnsweredCorrectly;          
        }

        private void NextFlashCard()
        {
            if (IndexPage.CardIndex < IndexPage.FlashCards.Count - 1)
            {
                if (IndexPage.CardIndex != IndexPage.FlashCards.Count - 1)
                {
                    IndexPage.CardIndex = FindNextIndex(IndexPage.CardIndex);
                    IndexPage.FlashCard = IndexPage.FlashCards[IndexPage.CardIndex];
                }
                SetFlashCardFront();
            }
        }

        private void LastFlashCard()
        {
            if (IndexPage.CardIndex >= 0 )
            {
                if (IndexPage.CardIndex != 0)
                {
                    IndexPage.CardIndex = FindPreviousIndex(IndexPage.CardIndex);
                    IndexPage.FlashCard = IndexPage.FlashCards[IndexPage.CardIndex];                        
                }
                SetFlashCardFront();
            }
        }

        // Finds index of next FlashCard in FlashCards list that has not been answered correctly (has AnsweredCorrectly == false)
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

        // Finds index of previous FlashCard in FlashCards list that has not been answered correctly (has AnsweredCorrectly == false)
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
            IndexPage.FlashCard.AnsweredCorrectly = IndexPage.AnsweredCorrectly;
            await FlashCardService.Update(IndexPage.FlashCard);
        }

        private void SetFlashCardFront()
        {

            IndexPage.Title = IndexPage.FlashCard.Title;
            IndexPage.Body = IndexPage.FlashCard.Front;
            IndexPage.AnsweredCorrectly = IndexPage.FlashCard.AnsweredCorrectly;
            IndexPage.Side = "Front";
            IndexPage.ShowButton = "Back";
        }

        private void SetFlashCardBack()
        {

            IndexPage.Title = IndexPage.FlashCard.Title;
            IndexPage.Body = IndexPage.FlashCard.Back;
            IndexPage.AnsweredCorrectly = IndexPage.FlashCard.AnsweredCorrectly;
            IndexPage.Side = "Back";
            IndexPage.ShowButton = "Front";
        }

        private void SetSelectedSuperSet(int id)
        {
            throw new NotImplementedException("SetSelectedSuperSet has not yet be implmemented");
        }

        private void LoadSuperSetSelectElements()
        {
            throw new NotImplementedException("LoadSuperSetSelectElements has not yet be implmemented");
        }

        private void LoadSupersetSets()
        {
            IndexPage.SelectedSets = IndexPage.Sets.Where(s => s.SupersetId == IndexPage.SelectedSupersetId).ToList();
            Console.WriteLine($"Sets for SupersetId {IndexPage.SelectedSupersetId} have been loaded.");
        }

        private void OnselectSupersetSelect(int id)
        {
            IndexPage.SelectedSetId = id;
        }

        private void LoadSetFlashCards()
        {
            throw new NotImplementedException("LoadSetFlashCards has not yet be implmemented");
        }

        private void Submit()
        {    
            //TODO: create submit action if needed.
            //throw new NotImplementedException("Submit has not yet be implmemented");
        }



    }
}
