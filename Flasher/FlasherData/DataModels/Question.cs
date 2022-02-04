using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlasherData.DataModels
{
    // tracks each flashcard in a test and whether the flashcard has been answered correctly or not.
    // Child of Test
    [Table("Questions")]
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        public bool AnsweredCorrectly { get; set; } = false;

        [Required]
        [ForeignKey("Tests")]
        public int TestId { get; set; }

        [Required]
        [ForeignKey("Flashcards")]
        public int FlashcardId { get; set; }

    }
}
