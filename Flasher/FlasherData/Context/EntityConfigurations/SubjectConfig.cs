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
    class SubjectConfig : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {

            builder.HasData(
                    new List<Subject>
                    {
                        new Subject{ Id = 1, Name = "CompTIA Security+ SY0-601 Practice Questions"},
                        new Subject{ Id = 2, Name = "Subject_2"},
                        new Subject{ Id = 3, Name = "Subject_3"},
                        new Subject{ Id = 4, Name = "Subject_4"}//,
                        //new Subject{ Id = 5, Name = "Subject_5"},
                        //new Subject{ Id = 6, Name = "Subject_6"},
                        //new Subject{ Id = 7, Name = "Subject_7"},
                        //new Subject{ Id = 8, Name = "Subject_8"}
                    }
                );

        }

    }
}
