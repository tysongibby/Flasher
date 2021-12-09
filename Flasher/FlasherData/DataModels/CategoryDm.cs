using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherData.DataModels
{
    [Table("Categories")]
    public class CategoryDm
    {
        [Key]        
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [ForeignKey("Subject")]
        [Column("SubjectId")]
        public int SubjectDmId { get; set; }

        // Navigation property for Flashcard FK relation
        public ICollection<FlashcardDm> FlashcardsDm { get; set; }
        //public virtual IEnumerable<FlashcardDm> FlashcardsDm { get; set; }

    }
}
