using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlasherWeb.Services.Models;
using FlasherWeb.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;

namespace FlasherWeb.Pages
{
    public partial class EditFlashCards
    {
        private string frontsTextAreaText;
        private string backsTextAreaText;       
        private string ResultsTextAreaText { get; set; } = string.Empty;
        private int FrontsTextAreaRows { get; set; }
        private int BacksTextAreaRows { get; set; }
        List<FlashCard> createdFlashCards = new List<FlashCard>();
        private List<FlashCard> NewflashCards { get; set; } = new List<FlashCard>();
        private string SuperSetTitle { get; set; } = string.Empty;
        private string SetTitle { get; set; } = string.Empty;

        [Inject]
        private IFlashCardService FlashCardService { get; set; }
        

        protected string FrontsTextAreaText
        {
            get => frontsTextAreaText;
            set 
            {
                frontsTextAreaText = value;
                FrontsTextAreaRows = CalculateRows(value);
            }
        }
        protected string BacksTextAreaText
        {
            get => backsTextAreaText;
            set
            {
                backsTextAreaText = value;
                BacksTextAreaRows = CalculateRows(value);
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
            Regex titleRegEx = new Regex(@"(\d|\d{2}|\d{3}).\s");
            

            foreach (string f in newFlashCardFronts)
            {
                var result = titleRegEx.Match(f);                
                FlashCard newFlashCard = new FlashCard()
                {
                    Title = result.ToString(),
                    Front = f             
                };
                //TODO: set newFlashCard.SupersetId
                //TODO: set newFlashCard.SetId
                NewflashCards.Add(newFlashCard);
            }

            for (int b = 0; b < NewflashCards.Count; b++ )
            {                
                NewflashCards[b].Back = newFlashCardBacks[b];
            }

            // add new flash cards to database
            foreach(FlashCard fc in NewflashCards)
            {                
                CreateFlashCard(fc);                
            }
            ResultsTextAreaText = $"{createdFlashCards.Count} flash cards have been added.";            
        }

        private async void CreateFlashCard(FlashCard fc)
        {
            FlashCard response = await FlashCardService.Create(fc);
            createdFlashCards.Add(response);
        }

    }
}
