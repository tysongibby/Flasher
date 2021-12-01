using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherWeb.Services.Models
{
    public class Flashcard
    {
        public int? Id { get; set; }
        public string Title { get; set; } = "Title Placeholder";
        public string Front { get; set; }
        public string Back { get; set; }
        public bool AnsweredCorrectly { get; set; } = false;
        public int SupersetId { get; set; }
        public int? SetId { get; set; }
    }
}
