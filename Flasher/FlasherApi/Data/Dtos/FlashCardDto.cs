using FlasherApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlasherApi.Data.Dtos
{
    public class FlashCardDto
    {   
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Front { get; set; }
        public string Back { get; set; }
        public bool AnsweredCorrectly { get; set; } = false;
        public int SupersetId { get; set; }
        public int? SetId { get; set; }        
    }
}
