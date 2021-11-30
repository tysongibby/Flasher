using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherData.Models
{
    public class SetModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        [ForeignKey("Superset")]
        public int SupersetId { get; set; }

        public virtual IEnumerable<FlashCardModel> FlashCards { get; set; }
       
    }
}
