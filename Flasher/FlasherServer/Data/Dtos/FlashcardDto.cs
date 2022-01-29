using FlasherData.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlasherServer.Data.Dtos
{
    public class FlashcardDto
    {   
        public int? Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Front { get; set; }
        public string Back { get; set; }
        public bool AnsweredCorrectly { get; set; } = false;
        public int SubjectId { get; set; }
        public int? CategoryId { get; set; }        
    }
}
