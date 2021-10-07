using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flasher.Shared.Data.Models;
using Flasher.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Flasher.Web.Pages
{
//    public partial class Index
//    {
//        [Inject]
//        private IFlasherService FlasherService { get; set; }
//        private List<FlashCard> FlashCards { get; set; } = new List<FlashCard>();
//        private int CardIndex { get; set; } = 0;
//        private bool Front { get; set; } = true;
//        private string FlashCardSide { get; set; } = "Front";

//        private string FlashCardBody { get; set; }
//        private string ShowButton { get; set; } = "Back";

//        //public Index(IFlasherService flasherService)
//        //{
//        //    FlasherService = flasherService;
//        //}

//        protected override async Task OnInitializedAsync()
//        {
//            //Console.WriteLine("OnIitializedAsync was called");
//            FlashCards = await FlasherService.GetAll();
//            //Console.WriteLine(FlashCards[0].Front);
//        }

//        public void NextFlashCard()
//        {
//            CardIndex++;
//        }

//        public void FlipFlashCard()
//        {
//            Front = !Front;
//            if (Front == true)
//            {
//                FlashCardSide = "Front";
//                ShowButton = "Back";
//                FlashCardBody = @FlashCards[CardIndex].Front;
//            }
//            else
//            {
//                FlashCardSide = "Back";
//                ShowButton = "Front";
//                FlashCardBody = @FlashCards[CardIndex].Back;
//            }
//        }

//    }
}
