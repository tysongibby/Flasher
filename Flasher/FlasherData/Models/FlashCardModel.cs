using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlasherData.Models
{
    public class FlashCardModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Front { get; set; }
        [Required]
        public string Back { get; set; }      
        public bool AnsweredCorrectly { get; set; } = false;
        
        //public virtual string Superset { get; set; }
        //public virtual string Set { get; set; }
        
        [Required]
        [ForeignKey("Superset")]
        public int SupersetId {get; set; }

       
        [ForeignKey("Set")]
        public int? SetId { get; set; }

        //public virtual Superset Superset { get; set; }
        //public virtual Superset Set { get; set; }
    }
}
