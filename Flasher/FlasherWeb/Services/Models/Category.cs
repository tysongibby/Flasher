using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherWeb.Services.Models
{
    public class Category
    {
       
        public int Id { get; set; }
        
        public string Title { get; set; }
                
        public int SubjectId { get; set; }

        //public virtual IEnumerable<Flashcard> Flashcards { get; set; }
       
    }
}
