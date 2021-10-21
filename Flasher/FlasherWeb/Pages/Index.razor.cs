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
        private ISupersetService SupersetService { get; set; }
        [Inject]
        private ISetService SetService { get; set; }
        [Inject]
        private IFlashCardService FlashCardService { get; set; }
        private List<FlashCard> FlashCards { get; set; } = new List<FlashCard>();
        private FlashCard FlashCard { get; set; } = new FlashCard();
        private int CardIndex { get; set; } = 0;
        private bool Front { get; set; } = true;
        private string Side { get; set; } = "Front";
        private string Title { get; set; } = string.Empty;
        private string Body { get; set; } = string.Empty;
        private string SupersetTitle { get; set; } = string.Empty;
        private List<Superset> Supersets { get; set; } = new List<Superset>();
        private string SetTitle { get; set; } = string.Empty;
        private List<Set> Sets { get; set; } = new List<Set>();
        private string ShowButton { get; set; } = "Back";
        private bool AnsweredCorrectly { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            Supersets = await SupersetService.GetAll();
            Sets = await SetService.GetAll();
            FlashCards = await FlashCardService.GetAll();    
            FlashCard = FlashCards[CardIndex];

            Body = FlashCard.Front;
            Title = FlashCard.Title;
            SupersetTitle = Supersets.Where(ss => ss.Id == FlashCard.SuperSetId).FirstOrDefault().Title;
            if (FlashCard.SetId is not null && FlashCard.SetId != 0)
            {
                SetTitle = Sets.Where(s => s.Id == FlashCard.SetId).FirstOrDefault().Title;
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
            
            Title = FlashCard.Title;
            Body = FlashCard.Front;
            AnsweredCorrectly = FlashCard.AnsweredCorrectly;
            Side = "Front";
            ShowButton = "Back";
        }

        private void SetFlashCardBack()
        {
            
            Title = FlashCard.Title;
            Body = FlashCard.Back;
            AnsweredCorrectly = FlashCard.AnsweredCorrectly;
            Side = "Back";
            ShowButton = "Front";
        }

        private void Submit()
        {
            Console.WriteLine("Page submit has been called.");
        }

    }
}
