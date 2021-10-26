﻿using FlasherWeb.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherWeb.Pages.Models
{
    public class IndexPage
    {
        public FlashCard FlashCard { get; set; } = new FlashCard();
        public List<FlashCard> FlashCards { get; set; } = new List<FlashCard>();
        public int CardIndex { get; set; } = 0;
        public bool Front { get; set; } = true;
        public string Side { get; set; } = "Front";
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string SupersetTitle { get; set; } = string.Empty;
        public List<Superset> Supersets { get; set; } = new List<Superset>();
        public string SetTitle { get; set; } = string.Empty;
        public List<Set> Sets { get; set; } = new List<Set>();
        public string ShowButton { get; set; } = "Back";
        public bool AnsweredCorrectly { get; set; } = false;
        public List<Set> SuperSetSelectElements { get; set; } = new List<Set>();
        public List<Set> SelectedSets { get; set; } = new List<Set>();
        public int SelectedSupersetId { get; set; } = 0;
        public int SelectedSetId { get; set; } = 0;

    }
}