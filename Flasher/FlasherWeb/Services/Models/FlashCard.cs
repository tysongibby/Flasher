﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherWeb.Services.Models
{
    public class FlashCard
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Front { get; set; }
        public string Back { get; set; }
        public bool AnsweredCorrectly { get; set; } = false;
        public int SuperSetId { get; set; }
        public int? SetId { get; set; }
    }
}
