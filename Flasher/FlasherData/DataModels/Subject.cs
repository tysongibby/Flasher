using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherData.DataModels
{
    // Represents the chosen segment of study
    // Parent of Category    
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        //Navigation property for Category FK relation
        public ICollection<Category> Categories { get; set; }

        //Navigation property for Test FK relation
        public virtual ICollection<Test> Tests { get; set; }

    }
}
