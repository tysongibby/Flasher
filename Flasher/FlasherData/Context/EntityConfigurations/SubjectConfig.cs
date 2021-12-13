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
                        new Subject{ Id = 1, Name = "Subject1"},
                        new Subject{ Id = 2, Name = "Subject2"},
                        new Subject{ Id = 3, Name = "Subject3"},
                        new Subject{ Id = 4, Name = "Subject4"},
                        new Subject{ Id = 5, Name = "Subject5"},
                        new Subject{ Id = 6, Name = "Subject6"},
                        new Subject{ Id = 7, Name = "Subject7"},
                        new Subject{ Id = 8, Name = "Subject8"}
                    }
                );

        }

    }
}
