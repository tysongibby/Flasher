using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlasherData.DataModels
{
    // Child of Test
    [Table("Questions")]
    public class QuestionDm
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Test")]
        public int Test { get; set; }

        [Required]
        [ForeignKey("Flashcard")]
        public int FlashcardId { get; set; }


    }
}
