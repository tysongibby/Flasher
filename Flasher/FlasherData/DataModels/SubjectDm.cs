using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherData.DataModels
{
    // Parent of Category
    [Table("Subjects")]
    public class SubjectDm
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        //Navigation property for Category FK relation
        public ICollection<CategoryDm> CategoriesDm { get; set; }

    }
}
