using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherData.Models
{
    public class SupersetModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public virtual IEnumerable<FlashCardModel> FlashCards { get; set; }
       
    }
}
