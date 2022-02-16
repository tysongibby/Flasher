using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlasherData.DataModels;

namespace FlasherData.Context.EntityConfigurations
{
    class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {            
            builder.HasData(
                    new List<Category>
                    {
                        new Category{ Id = 1, Name = "Threats, Attacks, and Vulnerabilities", SubjectId = 1},
                        new Category{ Id = 2, Name = "Architecture and Design", SubjectId = 1},
                        new Category{ Id = 3, Name = "Implementation", SubjectId = 1},
                        new Category{ Id = 4, Name = "Operations and Incident Response", SubjectId = 1},
                        new Category{ Id = 5, Name = "Governance, Risk, and Compliance", SubjectId = 1}//,
                        //new Category{ Id = 6, Name = "Category_6", SubjectId = 2},
                        //new Category{ Id = 7, Name = "Category_7", SubjectId = 2},
                        //new Category{ Id = 8, Name = "Category_8", SubjectId = 2}
                    }
                );

        }

    }
}
