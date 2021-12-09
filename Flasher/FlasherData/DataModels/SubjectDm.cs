using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherData.DataModels
{
    // Used to designate a particular segment of knowledge or learning
    // Parent of Category
    [Table("Subjects")]
    public class SubjectDm
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        //Navigation property for Category FK relation
        public ICollection<CategoryDm> Categories { get; set; }

        //Navigation property for Test FK relation
        public ICollection<TestDm> Tests { get; set; }

    }
}
