using FlasherData.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlasherApi.Data.Dtos
{
    public class Flashcard
    {   
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Front { get; set; }
        public string Back { get; set; }
        public bool AnsweredCorrectly { get; set; } = false;
        public int SubjectId { get; set; }
        public int? CategoryId { get; set; }        
    }
}
