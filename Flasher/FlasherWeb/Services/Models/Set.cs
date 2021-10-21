using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherWeb.Services.Models
{
    public class Set
    {
       
        public int Id { get; set; }
        
        public string Title { get; set; }
                
        public int SupersetId { get; set; }

        //public virtual IEnumerable<FlashCard> FlashCards { get; set; }
       
    }
}
