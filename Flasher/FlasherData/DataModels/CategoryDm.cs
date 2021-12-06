using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherData.DataModels
{
    public class CategoryDm
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        [ForeignKey("Subject")]
        public int SubjectDmId { get; set; }

        public virtual IEnumerable<FlashCardDm> FlashCardDms { get; set; }
       
    }
}
