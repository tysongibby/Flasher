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
    public partial class Import
    {
        private ImportPage ImportPage { get; set; } = new ImportPage();
        private string ResultsTextAreaText { get; set; } = string.Empty;
        private int FrontsTextAreaRows { get; set; }
        private int BacksTextAreaRows { get; set; }       
        private List<Flashcard> NewFlashcards { get; set; } = new List<Flashcard>();
        private string SubjectTitle { get; set; } = string.Empty;
        private string SetTitle { get; set; } = string.Empty;
        
        private string frontsTextAreaText;
        private string backsTextAreaText;
        List<string> createdFlashcardUrls = new List<string>();


        [Inject]
        private IFlashcardService FlashcardService { get; set; }
        

        protected string FrontsTextAreaText
        {
            get => frontsTextAreaText;
            set 
            {
                frontsTextAreaText = value;
                FrontsTextAreaRows = CalculateRows(value);
                //Console.WriteLine($"Fronts text area rows: {FrontsTextAreaRows}");
            }
        }
        protected string BacksTextAreaText
        {
            get => backsTextAreaText;
            set
            {
                backsTextAreaText = value;
                BacksTextAreaRows = CalculateRows(value);
                //Console.WriteLine($"Backs text area rows: {BacksTextAreaRows}");
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
            List<string> newFlashcardFronts = textForFronts.Split('■').ToList();
            List<string> newFlashcardBacks = textForBacks.Split('■').ToList();
            Regex titleRegEx = new Regex(@"(\d|\d{2}|\d{3}).\s");
            
            if (newFlashcardFronts.Count == newFlashcardBacks.Count)
            {                                
                int i = 0;
                while (i <= (newFlashcardFronts.Count - 1))
                {                    
                    string _title = titleRegEx.Match(newFlashcardFronts[i]).ToString();
                    if (_title is null || _title == string.Empty)
                    {
                        _title = "Temp Title";
                    }
                    Flashcard newFlashcard = new Flashcard()
                    {                        
                        SubjectId = 1,
                        CategoryId = 5,
                        Title = _title,
                        Front = newFlashcardFronts[i],
                        Back = newFlashcardBacks[i]
                    };
                    //TODO: get Subject from webform
                    //TODO: get Category from webform
                    NewFlashcards.Add(newFlashcard);
                    i++;
                }
            }
            else 
            {
                throw new Exception($"Flashcard fronts and flashcard backs must be equal in number:\nFronts = {newFlashcardFronts.Count}, Backs = {newFlashcardBacks.Count}");
            }

            // add new flashcards to database
            foreach (Flashcard fc in NewFlashcards)
            {                
                CreateFlashcardAsync(fc);                
            }
            ResultsTextAreaText = $"{createdFlashcardUrls.Count} flashcards have been added.";            
        }

        private async void CreateFlashcardAsync(Flashcard fc)
        {
            if (fc is not null)
            {
                string response = await FlashcardService.Create(fc);
                createdFlashcardUrls.Add(response);
            }
        }

    }
}
