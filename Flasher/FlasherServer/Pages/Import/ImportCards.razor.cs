using AutoMapper;
using FlasherData.DataModels;
using FlasherData.Repositories;
using FlasherData.Repositories.Interfaces;
using FlasherServer.Data.Dtos;
using FlasherServer.Pages.Import.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlasherServer.Pages.Import
{
    public partial class ImportCards
    {
        private ImportCardsPage Page { get; set; } = new ImportCardsPage();
        private string FrontsTextAreaText { get; set; } = string.Empty;
        private int FrontsTextAreaRows { get; set; }
        private string BacksTextAreaText { get; set; } = string.Empty;
        private int BacksTextAreaRows { get; set; }
        private IList<FlashcardDto> NewFlashcards { get; set; } = new List<FlashcardDto>();
        private string ResultsTextAreaText { get; set; } = string.Empty;
        
        [Inject]
        private IUnitOfWork UnitOfWork { get; set; }
        [Inject]
        private IMapper Mapper { get; set; }
        [Parameter]
        public string selectedsubjectid { get; set; }
        [Parameter]
        public string selectedcategoryid { get; set; }
        private int SelectedSubjectId { get; set; }
        private int SelectedCategoryId { get; set; }

        protected override void OnInitialized()
        {
            SelectedSubjectId = int.Parse(selectedsubjectid);
            SelectedCategoryId = int.Parse(selectedcategoryid);
        }

        public void Submit(string textForFronts, string textForBacks)
        {
            List<string> newFlashcardFronts = textForFronts.Split('■').ToList();
            List<string> newFlashcardBacks = textForBacks.Split('■').ToList();
            Regex nameRegEx = new Regex(@"(\d|\d{2}|\d{3}).\s");

            if (newFlashcardFronts.Count == newFlashcardBacks.Count)
            {
                int i = 0;
                while (i <= (newFlashcardFronts.Count - 1))
                {
                    string _name = nameRegEx.Match(newFlashcardFronts[i]).ToString();
                    if (_name is null || _name == string.Empty)
                    {
                        _name = "Temp Name";
                    }
                    FlashcardDto newFlashcard = new FlashcardDto()
                    {
                        SubjectId = SelectedSubjectId,
                        CategoryId = SelectedCategoryId,
                        Name = _name,
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
            foreach (FlashcardDto fc in NewFlashcards)
            {
                UnitOfWork.Flashcards.Add(Mapper.Map<Flashcard>(fc));
            }
            ResultsTextAreaText = $"{NewFlashcards.Count} flashcards have been added.";
        }
    }


}
