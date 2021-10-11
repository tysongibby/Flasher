using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlasherShared.Data.Models;
using FlasherWeb.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace FlasherWeb.Pages
{
    public partial class Index
    {
        [Inject]
        private IFlashCardService FlashCardService { get; set; }
        private List<FlashCard> FlashCards { get; set; } = new List<FlashCard>();
        private int CardIndex { get; set; } = 0;
        private bool Front { get; set; } = true;
        private string FlashCardSide { get; set; } = "Front";
        private string FlashCardTitle { get; set; } = string.Empty;
        private string FlashCardBody { get; set; } = string.Empty;
        private string ShowButton { get; set; } = "Back";
        private bool AnsweredCorrectly { get; set; } = false;

        //public Index(IFlashCardService flashCardService)
        //{
        //    FlashCardService = flashCardService;
        //}

        protected override async Task OnInitializedAsync()
        {            
            FlashCards = await FlashCardService.GetAll();
            //Console.WriteLine($"FlashCard: {FlashCards[0].Id}, {FlashCards[0].Front}, {FlashCards[0].Back}");
            FlashCardBody = FlashCards[CardIndex].Front;
            FlashCardTitle = FlashCards[CardIndex].Title;
            AnsweredCorrectly = FlashCards[CardIndex].AnsweredCorrectly;

        }

        public void NextFlashCard()
        {
            if (CardIndex < FlashCards.Count - 1)
            {
                if (CardIndex != FlashCards.Count - 1)
                {
                    CardIndex++;
                }
                if (Front)
                {
                    SetFlashCardFront(FlashCards[CardIndex]);
                }
                else
                {
                    SetFlashCardBack(FlashCards[CardIndex]);
                }
            }
        }
        public void LastFlashCard()
        {
            if (CardIndex >= 0 )
            {
                if (CardIndex != 0)
                {
                    CardIndex--;
                }
                if (Front)
                {
                    SetFlashCardFront(FlashCards[CardIndex]);
                }
                else
                {
                    SetFlashCardBack(FlashCards[CardIndex]);
                }
            }
        }

        public void FlipFlashCard()
        {
            Front = !Front;
            if (Front == true)
            {
                FlashCardSide = "Front";
                ShowButton = "Back";
                FlashCardBody = @FlashCards[CardIndex].Front;
            }
            else
            {
                FlashCardSide = "Back";
                ShowButton = "Front";
                FlashCardBody = @FlashCards[CardIndex].Back;
            }
        }

        public void UpdateAnswerStatus()
        {
            AnsweredCorrectly = !AnsweredCorrectly;
            FlashCards[CardIndex].AnsweredCorrectly = AnsweredCorrectly;
            FlashCardService.Update(FlashCards[CardIndex]);
        }

        private void SetFlashCardFront(FlashCard fc)
        {
            FlashCardTitle = fc.Title;
            FlashCardBody = fc.Front;
            AnsweredCorrectly = fc.AnsweredCorrectly;            
        }

        private void SetFlashCardBack(FlashCard fc)
        {
            FlashCardTitle = fc.Title;
            FlashCardBody = fc.Back;
            AnsweredCorrectly = fc.AnsweredCorrectly;           
        }


    }
}
