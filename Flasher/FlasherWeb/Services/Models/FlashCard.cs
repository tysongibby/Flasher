using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherWeb.Services.Models
{
    public class Flashcard
    {
        public int? Id { get; set; }
        public string Name { get; set; } = "Name Placeholder";
        public string Front { get; set; }
        public string Back { get; set; }
        public bool AnsweredCorrectly { get; set; } = false;
        public int SubjectId { get; set; }
        public int? CategoryId { get; set; }
    }
}
