using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlasherShared.Data.Models;
using FlasherWeb.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace FlasherWeb.Pages
{
    public partial class EditFlashCards
    {
        private string textArea1Text;
        private string textArea2Text;
        //private FlashCard flashCard;
        private int TextArea1Rows { get; set; }
        private int TextArea2Rows { get; set; }
        private List<FlashCard> NewflashCards { get; set; } = new List<FlashCard>();
        [Inject]
        private IFlashCardService FlashCardService { get; set; }
        //public EditFlashCards()
        //{            
        //}

        protected string TextArea1Text
        {
            get => textArea1Text;
            set 
            {
                textArea1Text = value;
                TextArea1Rows = CalculateRows(value);
            }
        }
        protected string TextArea2Text
        {
            get => textArea2Text;
            set
            {
                textArea2Text = value;
                TextArea2Rows = CalculateRows(value);
            }
        }

        private int CalculateRows(string textToCalculate)
        {
            int textAreaRows = Math.Max(textToCalculate.Split('\n').Length, textToCalculate.Split('\r').Length);
            textAreaRows = Math.Max(textAreaRows, 2);
            return textAreaRows;
        }

        public void Submit(string textForFronts, string textForBacks)
        {
            List<string> newFlashCardFronts = textForFronts.Split('■').ToList();
            List<string> newFlashCardBacks = textForBacks.Split('■').ToList();
            //foreach (string fc in newFlashCardFronts)
            //{
            //    Console.WriteLine(fc);
            //}
            //foreach (string bc in newFlashCardBacks)
            //{
            //    Console.WriteLine(bc);
            //}
            foreach (string f in newFlashCardFronts)
            {
                FlashCard newFlashCard = new FlashCard()
                {
                    Front = f
                };
                NewflashCards.Add(newFlashCard);
            }

            for (int b = 0; b < NewflashCards.Count; b++ )
            {                
                NewflashCards[b].Back = newFlashCardBacks[b];
            }

            //TODO: add new flash cards to database
            foreach(FlashCard fc in NewflashCards)
            {
                var result = FlashCardService.Create(fc).Result;
            }
            
            
        }

    }
}
