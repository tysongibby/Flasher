using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherServer.Data.Dtos
{
    public class SubjectDto
    { 
        public int? Id { get; set; }        
        public string Name { get; set; } 
    }
}
