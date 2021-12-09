using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlasherData.DataModels
{
    // Group of FlashCards used for a round of testing
    // Parent of Question
    [Table("Tests")]
    public class TestDm
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        [Required]
        [ForeignKey("Subjects")]
        public SubjectDm Subject { get; set; }

        // Navigation property for Question FK relation
        public ICollection<QuestionDm> Questions { get; set; }

        
        //public ICollection<CategoryDm> Category { get; set; }
    }
}
