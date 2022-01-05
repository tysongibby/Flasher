using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlasherData.DataModels
{
    // Used to faciliate the study of a question (front of card) and answer (back of card) in a "flashcard" format
    // Child of Category    
    public class Flashcard
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Front { get; set; }

        [Required]
        public string Back { get; set; }      

        public bool AnsweredCorrectly { get; set; } = false;

        [Required]
        [ForeignKey("Categories")]        
        public int CategoryId { get; set; }

        // Navigation property for Question FK relation
        ICollection<Question> Questions { get; set; }

    }
}
