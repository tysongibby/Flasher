using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherApi.Data.Models
{
    public class Set
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        [ForeignKey("Superset")]
        public int SupersetId { get; set; }

        public virtual IEnumerable<FlashCard> FlashCards { get; set; }
       
    }
}
