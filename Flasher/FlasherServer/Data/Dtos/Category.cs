using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherServer.Data.Dtos
{
    public class Category
    {        
        public int? Id { get; set; }     
        public string Title { get; set; }    
        public int SubjectId { get; set; }
    }
}
