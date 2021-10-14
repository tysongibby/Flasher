using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherWeb.Services.Models
{
    public class FlashCardSet
    {        
        public int Id { get; set; }
        public string Title { get; set; }


        public FlashCardSet FlashCardSuperset { get; set; }
    }
}
