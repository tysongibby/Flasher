using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherData.DataModels
{
    public class SubjectDm
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public virtual IEnumerable<FlashCardDm> FlashCardDbs { get; set; }
       
    }
}
