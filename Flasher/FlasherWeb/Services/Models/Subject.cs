﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherWeb.Services.Models
{
    public class Subject
    {
       
        public int Id { get; set; }
       
        public string Title { get; set; }

        //public virtual IEnumerable<Flashcard> Flashcards { get; set; }
       
    }
}