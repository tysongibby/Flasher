using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlasherWeb.Services.Models;
using FlasherWeb.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;
using FlasherWeb.Pages.Models;

namespace FlasherWeb.Pages
{
    public partial class EditFlashCards
    {
        private EditFlashCardsPage FlashCardsPage { get; set; } = new EditFlashCardsPage();
        private string ResultsTextAreaText { get; set; } = string.Empty;
        private int FrontsTextAreaRows { get; set; }
        private int BacksTextAreaRows { get; set; }
        List<FlashCard> createdFlashCards = new List<FlashCard>();
        private List<FlashCard> NewflashCards { get; set; } = new List<FlashCard>();
        private string SuperSetTitle { get; set; } = string.Empty;
        private string SetTitle { get; set; } = string.Empty;
        
        private string frontsTextAreaText;
        private string backsTextAreaText;


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
                Console.WriteLine($"Fronts text area rows: {FrontsTextAreaRows}\n Backs text area rows: {BacksTextAreaRows}");
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
            if (newFlashCardFronts.Count == newFlashCardBacks.Count)
            {
                for (int i = 0; i <= newFlashCardFronts.Count - 1; i++)
                {
                    var result = titleRegEx.Match(newFlashCardFronts[i]);
                    FlashCard newFlashCard = new FlashCard()
                    {
                        SuperSetId = 2,
                        SetId = 2,
                        Title = result.ToString(),
                        Front = newFlashCardFronts[i],
                        Back = newFlashCardBacks[i]
                    };
                    //TODO: get Superset from webform
                    //TODO: get set from webform
                    NewflashCards.Add(newFlashCard);
                }
            }
            else 
            {
                throw new Exception($"Flash card fronts and flash card backs must be equal in number: Fronts = {newFlashCardFronts.Count}, Backs = {newFlashCardBacks.Count}");
            }

            //foreach (string f in newFlashCardFronts)
            //{
            //    var result = titleRegEx.Match(f);                
            //    FlashCard newFlashCard = new FlashCard()
            //    {
            //        SuperSetId = 1,
            //        SetId = 1,
            //        Title = result.ToString(),
            //        Front = f                     
            //    };
            //    //TODO: get new Superset from webform
            //    //TODO: get new set from webform
            //    NewflashCards.Add(newFlashCard);
            //}

            //for (int b = 0; b <= NewflashCards.Count - 1; b++ )
            //{                
            //    NewflashCards[b].Back = newFlashCardBacks[b];
            //}

            // add new flash cards to database
            foreach (FlashCard fc in NewflashCards)
            {                
                CreateFlashCardAsync(fc);                
            }
            ResultsTextAreaText = $"{NewflashCards.Count} flash cards have been added.";            
        }

        private async void CreateFlashCardAsync(FlashCard fc)
        {
            if (fc is not null)
            {
                FlashCard response = await FlashCardService.Create(fc);
                createdFlashCards.Add(response);
            }
        }

    }
}
