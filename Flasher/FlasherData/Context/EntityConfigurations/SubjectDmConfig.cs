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
    class SubjectDmConfig : IEntityTypeConfiguration<SubjectDm>
    {
        public void Configure(EntityTypeBuilder<SubjectDm> builder)
        {

            builder.HasData(
                    new List<SubjectDm>
                    {
                        new SubjectDm{ Id = 1, Name = "Subject1"},
                        new SubjectDm{ Id = 2, Name = "Subject2"},
                        new SubjectDm{ Id = 3, Name = "Subject3"},
                        new SubjectDm{ Id = 4, Name = "Subject4"},
                        new SubjectDm{ Id = 5, Name = "Subject5"},
                        new SubjectDm{ Id = 6, Name = "Subject6"},
                        new SubjectDm{ Id = 7, Name = "Subject7"},
                        new SubjectDm{ Id = 8, Name = "Subject8"}
                    }
                );

        }

    }
}
