using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlasherWeb.Services.Models;
using FlasherWeb.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace FlasherWeb.Pages
{
    public partial class Index
    {
        [Inject]
        private IFlashCardService FlashCardService { get; set; }
        private List<FlashCard> FlashCards { get; set; } = new List<FlashCard>();
        private FlashCard FlashCard { get; set; } = new FlashCard();
        private int CardIndex { get; set; } = 0;
        private bool Front { get; set; } = true;
        private string FlashCardSide { get; set; } = "Front";
        private string FlashCardTitle { get; set; } = string.Empty;
        private string FlashCardBody { get; set; } = string.Empty;
        private string SuperSet { get; set; } = string.Empty;
        private List<string> SuperSets { get; set; } = new List<string>();
        private string Set { get; set; } = string.Empty;
        private List<string> Sets { get; set; } = new List<string>();
        private string ShowButton { get; set; } = "Back";
        private bool AnsweredCorrectly { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {            
            FlashCards = await FlashCardService.GetAll();            
            FlashCard = FlashCards[CardIndex];
            FlashCardBody = FlashCard.Front;
            FlashCardTitle = FlashCard.Title;
            var result = FlashCards.Where(fc => !string.IsNullOrEmpty(fc.Set) && !string.IsNullOrWhiteSpace(fc.Set))
                            .Distinct()
                            .ToList();
            if (FlashCard.SuperSet is not null || FlashCard.SuperSet != string.Empty)
            {
                SuperSet = FlashCard.SuperSet;
                if (FlashCard.Set is not null || FlashCard.Set != string.Empty)
                {
                    Set = FlashCard.Set;
                }
            }
            AnsweredCorrectly = FlashCard.AnsweredCorrectly;

        }

        public void NextFlashCard()
        {
            if (CardIndex < FlashCards.Count - 1)
            {
                if (CardIndex != FlashCards.Count - 1)
                {
                    CardIndex++;
                    FlashCard = FlashCards[CardIndex];
                }
                SetFlashCardFront();
            }
        }

        public void LastFlashCard()
        {
            if (CardIndex >= 0 )
            {
                if (CardIndex != 0)
                {
                    CardIndex--;
                    FlashCard = FlashCards[CardIndex];
                }
                SetFlashCardFront();
            }
        }

        public void FlipFlashCard()
        {
            Front = !Front;
            if (Front == true)
            {
                SetFlashCardFront();                
            }
            else
            {
                SetFlashCardBack();
            }
        }

        public async void UpdateAnswerStatus()
        {
            AnsweredCorrectly = !AnsweredCorrectly;
            FlashCard.AnsweredCorrectly = AnsweredCorrectly;
            await FlashCardService.Update(FlashCard);
        }

        private void SetFlashCardFront()
        {
            
            FlashCardTitle = FlashCard.Title;
            FlashCardBody = FlashCard.Front;
            AnsweredCorrectly = FlashCard.AnsweredCorrectly;
            FlashCardSide = "Front";
            ShowButton = "Back";
        }

        private void SetFlashCardBack()
        {
            
            FlashCardTitle = FlashCard.Title;
            FlashCardBody = FlashCard.Back;
            AnsweredCorrectly = FlashCard.AnsweredCorrectly;
            FlashCardSide = "Back";
            ShowButton = "Front";
        }

        private void Submit()
        {
            Console.WriteLine("Page submit has been called.");
        }

    }
}
