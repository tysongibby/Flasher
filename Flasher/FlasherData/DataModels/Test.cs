using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlasherData.DataModels
{
    // Group of FlashCards used for a round of testing for a subject
    // Parent of Question    
    public class Test
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        [Required]
        [ForeignKey("Subjects")]
        public int SubjectId { get; set; }

        // Navigation property for Question FK relation
        public ICollection<Question> Questions { get; set; }

        
        //public ICollection<Category> Category { get; set; }
    }
}
