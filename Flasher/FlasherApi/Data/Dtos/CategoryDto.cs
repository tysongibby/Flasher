using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherApi.Data.Dtos
{
    public class CategoryDto
    {        
        public int? Id { get; set; }     
        public string Title { get; set; }    
        public int SubjectId { get; set; }
    }
}
