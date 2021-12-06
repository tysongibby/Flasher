using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;
using FlasherServer.Pages.Models;
using FlasherServer.Data.Dtos;
using FlasherData.Repositories.Interfaces;
using AutoMapper;
using FlasherData.DataModels;

namespace FlasherServer.Pages
{
    public partial class Import
    {
        private ImportPage ImportPage { get; set; } = new ImportPage();
        private string ResultsTextAreaText { get; set; } = string.Empty;
        private int FrontsTextAreaRows { get; set; }
        private int BacksTextAreaRows { get; set; }
        private List<Flashcard> NewflashCards { get; set; } = new List<Flashcard>();
        private string SubjectTitle { get; set; } = string.Empty;
        private string CategoryTitle { get; set; } = string.Empty;

        private string frontsTextAreaText;
        private string backsTextAreaText;
        List<string> createdFlashCardUrls = new List<string>();
        

        [Inject]
        private IUnitOfWork UnitOfWork { get; set; }
        [Inject]
        private IMapper Mapper { get; set; }

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
            List<string> newFlashCardFronts = textForFronts.Split('■').ToList();
            List<string> newFlashCardBacks = textForBacks.Split('■').ToList();
            Regex titleRegEx = new Regex(@"(\d|\d{2}|\d{3}).\s");

            if (newFlashCardFronts.Count == newFlashCardBacks.Count)
            {
                int i = 0;
                while (i <= (newFlashCardFronts.Count - 1))
                {
                    string _title = titleRegEx.Match(newFlashCardFronts[i]).ToString();
                    if (_title is null || _title == string.Empty)
                    {
                        _title = "Temp Title";
                    }
                    Flashcard newFlashCard = new Flashcard()
                    {
                        SubjectId = 1,
                        CategoryId = 5,
                        Title = _title,
                        Front = newFlashCardFronts[i],
                        Back = newFlashCardBacks[i]
                    };
                    //TODO: get Subject from webform
                    //TODO: get Category from webform
                    NewflashCards.Add(newFlashCard);
                    i++;
                }
            }
            else
            {
                throw new Exception($"Flash card fronts and flash card backs must be equal in number:\nFronts = {newFlashCardFronts.Count}, Backs = {newFlashCardBacks.Count}");
            }

            // add new flash cards to database
            foreach (Flashcard fc in NewflashCards)
            {
                UnitOfWork.FlashCardDms.Add(Mapper.Map<FlashCardDm>(fc));
            }
            ResultsTextAreaText = $"{createdFlashCardUrls.Count} flash cards have been added.";
        }



    }
}

