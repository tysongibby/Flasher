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

        public bool AnsweredCorrectly { get; set; }

        [Required]
        [ForeignKey("Test")]
        public int Test { get; set; }

        [Required]
        [ForeignKey("Flashcard")]
        public int FlashcardId { get; set; }

    }
}
