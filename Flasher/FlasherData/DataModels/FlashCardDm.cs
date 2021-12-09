using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlasherData.DataModels
{
    [Table("Flashcards")]
    public class FlashcardDm
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Front { get; set; }

        [Required]
        public string Back { get; set; }      

        public bool AnsweredCorrectly { get; set; } = false;

        [Required]
        [ForeignKey("Category")]
        [Column("CategoryId")]
        public int CategoryDmId { get; set; }

    }
}
