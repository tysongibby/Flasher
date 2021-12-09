using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherData.DataModels
{
    // Used to designate smaller segments of a subject of study
    // Child of Subject, Parent of Flashcard
    [Table("Categories")]
    public class CategoryDm
    {
        [Key]        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey("Subject")]        
        public int SubjectId { get; set; }

        // Navigation property for Flashcard FK relation
        public ICollection<FlashcardDm> Flashcards { get; set; }        

    }
}
