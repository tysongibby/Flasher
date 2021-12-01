using AutoMapper;
using FlasherData.Models;
using FlasherData.Repositories.Interfaces;
using FlasherServer.Data.Dtos;
using FlasherServer.Pages.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherServer.Pages
{
    public partial class View
    {
        [Inject]
        private IUnitOfWork UnitOfWork { get; set; }
        [Inject]
        private IMapper Mapper { get; set; }
        private ViewPage ViewPage { get; set; } = new ViewPage();
        //private List<FlashCard> FlashCards { get; set; } = new List<FlashCard>();
        //private FlashCard FlashCard { get; set; } = new FlashCard();
        //private int CardIndex { get; set; } = 0;
        //private bool Front { get; set; } = true;
        //private string Side { get; set; } = "Front";
        //private string Title { get; set; } = string.Empty;
        //private string Body { get; set; } = string.Empty;
        //private string SupersetTitle { get; set; } = string.Empty;
        //private List<Superset> Supersets { get; set; } = new List<Superset>();
        //private string SetTitle { get; set; } = string.Empty;
        //private List<Set> Sets { get; set; } = new List<Set>();
        //private string ShowButton { get; set; } = "Back";
        //private bool AnsweredCorrectly { get; set; } = false;        
        //private List<Set> SuperSetSelectElements { get; set; } = new List<Set>();
        //private List<Set> SelectedSets { get; set; } = new List<Set>();
        //private int SelectedSupersetId { get; set; } = 0;
        //private int SelectedSetId { get; set; } = 0;        

        protected override void OnInitialized()
        {
            // get all Supersets from db
            List<SupersetModel> supersetModels = UnitOfWork.Supersets.GetAll().ToList();
            foreach (SupersetModel supersetModel in supersetModels)
            {
                // convert data model to dto
                ViewPage.Supersets.Add(Mapper.Map<Superset>(supersetModel));
            }
            // get all Sets from db
            IList<SetModel> setModels = UnitOfWork.Sets.GetAll();
            foreach (SetModel setModel in setModels)
            {
                // convert data model to dto
                ViewPage.Sets.Add(Mapper.Map<Set>(setModel));
            }
            // get all FlashCards db
            IList<FlashCardModel> flashCardModels = UnitOfWork.FlashCards.GetAll();
            foreach (FlashCardModel flashCardModel in flashCardModels)
            {
                // convert data model to dto
                ViewPage.FlashCards.Add(Mapper.Map<FlashCard>(flashCardModel));
            }
            // get FlashCard to be displayed on page
            ViewPage.FlashCard = ViewPage.FlashCards[ViewPage.CardIndex];

            // set data to be displayed on page
            ViewPage.Body = ViewPage.FlashCard.Front;
            ViewPage.Title = ViewPage.FlashCard.Title;
            ViewPage.SupersetTitle = ViewPage.Supersets.Where(ss => ss.Id == ViewPage.FlashCard.SupersetId).FirstOrDefault().Title;
            if (ViewPage.FlashCard.SetId is not null && ViewPage.FlashCard.SetId != 0)
            {
                ViewPage.SetTitle = ViewPage.Sets.Where(s => s.Id == ViewPage.FlashCard.SetId).FirstOrDefault().Title;
            }
            ViewPage.AnsweredCorrectly = ViewPage.FlashCard.AnsweredCorrectly;
        }

        private void NextFlashCard()
        {
            if (ViewPage.CardIndex < ViewPage.FlashCards.Count - 1)
            {
                if (ViewPage.CardIndex != ViewPage.FlashCards.Count - 1)
                {
                    ViewPage.CardIndex = FindNextIndex(ViewPage.CardIndex);
                    ViewPage.FlashCard = ViewPage.FlashCards[ViewPage.CardIndex];
                    ViewPage.SupersetTitle = ViewPage.Supersets.Where(ss => ss.Id == ViewPage.FlashCard.SupersetId).FirstOrDefault().Title;
                    ViewPage.SetTitle = ViewPage.Sets.Where(s => s.Id == ViewPage.FlashCard.SetId).FirstOrDefault().Title;
                }
                SetFlashCardFront();
            }
            ViewPage.Counter++;
        }

        private void LastFlashCard()
        {
            if (ViewPage.CardIndex >= 0)
            {
                if (ViewPage.CardIndex != 0)
                {
                    ViewPage.CardIndex = FindPreviousIndex(ViewPage.CardIndex);
                    ViewPage.FlashCard = ViewPage.FlashCards[ViewPage.CardIndex];
                }
                SetFlashCardFront();
            }
        }

        // Finds index of next FlashCard in FlashCards list that has not been answered correctly (has AnsweredCorrectly == false)
        private int FindNextIndex(int currentIndex)
        {
            // finds the index of the last incorrect answer (AnsweredCorrectly == false)
            int _lastIncorrectAnswerIndex = -100;
            if (ViewPage.FlashCards[currentIndex].AnsweredCorrectly == false)
            {
                _lastIncorrectAnswerIndex = currentIndex;
            }
            else
            {
                int x = currentIndex;
                while (_lastIncorrectAnswerIndex == -100 && x > 0)
                {
                    if (ViewPage.FlashCards[x].AnsweredCorrectly == false)
                    {
                        _lastIncorrectAnswerIndex = currentIndex;
                    }
                    else
                    {
                        x--;
                    }
                }
            }

            // returns the index of the next incorrect answer (AnsweredCorrectly == false)
            // if remaining answers are all correct (AnsweredCorrectly == true), _lastIncorrectAnswerIndex is returned
            int i = currentIndex;
            while (i <= ViewPage.FlashCards.Count - 1)
            {
                if (i != currentIndex && ViewPage.FlashCards[i].AnsweredCorrectly == false)
                {
                    return i;
                }
                else
                {
                    i++;
                }
            }
            return _lastIncorrectAnswerIndex;

        }

        // Finds index of previous FlashCard in FlashCards list that has not been answered correctly (has AnsweredCorrectly == false)
        private int FindPreviousIndex(int currentIndex)
        {
            // finds the index of the latest incorrect answer (AnsweredCorrectly == false)
            int _latestIncorrectAnswerIndex = -100;
            if (ViewPage.FlashCards[currentIndex].AnsweredCorrectly == false)
            {
                _latestIncorrectAnswerIndex = currentIndex;
            }
            else
            {
                int x = currentIndex;
                while (_latestIncorrectAnswerIndex == -100 && x < ViewPage.FlashCards.Count - 1)
                {
                    if (ViewPage.FlashCards[x].AnsweredCorrectly == false)
                    {
                        _latestIncorrectAnswerIndex = currentIndex;
                    }
                    else
                    {
                        x++;
                    }
                }
            }

            // returns the index of the previous incorrect answer (AnsweredCorrectly == false)
            // if previous answers are all correct (AnsweredCorrectly == true), _latestIncorrectAnswerIndex is returned
            int i = currentIndex;
            while (i >= 0)
            {
                if (i != currentIndex && ViewPage.FlashCards[i].AnsweredCorrectly == false)
                {
                    return i;
                }
                else
                {
                    i--;
                }
            }
            return _latestIncorrectAnswerIndex;
        }

        private void FlipFlashCard()
        {
            ViewPage.Front = !ViewPage.Front;
            if (ViewPage.Front == true)
            {
                SetFlashCardFront();
            }
            else
            {
                SetFlashCardBack();
            }
        }

        private void UpdateAnswerStatus()
        {
            ViewPage.AnsweredCorrectly = !ViewPage.AnsweredCorrectly;
            ViewPage.FlashCard.AnsweredCorrectly = ViewPage.AnsweredCorrectly;
            int pk = UnitOfWork.FlashCards.Update(Mapper.Map<FlashCardModel>(ViewPage.FlashCard));
        }

        private void SetFlashCardFront()
        {

            ViewPage.Title = ViewPage.FlashCard.Title;
            ViewPage.Body = ViewPage.FlashCard.Front;
            ViewPage.AnsweredCorrectly = ViewPage.FlashCard.AnsweredCorrectly;
            ViewPage.Side = "Front";
            ViewPage.ShowButton = "Back";
        }

        private void SetFlashCardBack()
        {

            ViewPage.Title = ViewPage.FlashCard.Title;
            ViewPage.Body = ViewPage.FlashCard.Back;
            ViewPage.AnsweredCorrectly = ViewPage.FlashCard.AnsweredCorrectly;
            ViewPage.Side = "Back";
            ViewPage.ShowButton = "Front";
        }

        private void SetSelectedSuperSet(int id)
        {
            throw new NotImplementedException("SetSelectedSuperSet has not yet be implmemented");
        }

        private void LoadSuperSetSelectElements()
        {
            throw new NotImplementedException("LoadSuperSetSelectElements has not yet be implmemented");
        }

        private void LoadSupersetSets()
        {
            ViewPage.SelectedSets = ViewPage.Sets.Where(s => s.SupersetId == ViewPage.SelectedSupersetId).ToList();
            Console.WriteLine($"Sets for SupersetId {ViewPage.SelectedSupersetId} have been loaded.");
        }

        private void OnselectSupersetSelect(int id)
        {
            ViewPage.SelectedSetId = id;
        }

        private void LoadSetFlashCards()
        {
            throw new NotImplementedException("LoadSetFlashCards has not yet be implmemented");
        }

        private void Submit()
        {
            //TODO: create submit action if needed.
            //throw new NotImplementedException("Submit has not yet be implmemented");
        }



    }
}

