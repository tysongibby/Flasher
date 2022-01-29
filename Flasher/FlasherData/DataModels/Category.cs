using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherData.DataModels
{
    // Represents the sub-segments of the chosen segment of study
    // Child of Subject, Parent of Flashcard
    [Table("Categories")]
    public class Category
    {
        [Key]        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey("Subject")]        
        public int SubjectId { get; set; }

        // Navigation property for Flashcard FK relation
        public ICollection<Flashcard> Flashcards { get; set; }        

    }
}
