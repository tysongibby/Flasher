﻿using FlasherServer.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherServer.Pages.Study.Models
{
    public class StudyFlashcardsPage
    {
        public Flashcard Flashcard { get; set; } = new Flashcard();
        public List<Flashcard> Flashcards { get; set; } = new List<Flashcard>();
        public int CardIndex { get; set; } = 0;
        public bool Front { get; set; } = true;
        public string Side { get; set; } = "Front";
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string SubjectTitle { get; set; } = string.Empty;
        public Subject Subject { get; set; } = new Subject();
        public string CategoryTitle { get; set; } = string.Empty;
        public List<Category> Categories { get; set; } = new List<Category>();
        public string ShowButton { get; set; } = "Back";
        public bool AnsweredCorrectly { get; set; } = false;

        public int Counter { get; set; } = 0; //TEMP property until list object features are implemented

    }
}