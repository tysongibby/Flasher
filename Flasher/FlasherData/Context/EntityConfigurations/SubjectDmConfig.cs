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
                        new SubjectDm{ Id = 1, Title = "Subject1"},
                        new SubjectDm{ Id = 2, Title = "Subject2"},
                        new SubjectDm{ Id = 3, Title = "Subject3"},
                        new SubjectDm{ Id = 4, Title = "Subject4"},
                        new SubjectDm{ Id = 5, Title = "Subject5"},
                        new SubjectDm{ Id = 6, Title = "Subject6"},
                        new SubjectDm{ Id = 7, Title = "Subject7"},
                        new SubjectDm{ Id = 8, Title = "Subject8"}
                    }
                );

        }

    }
}
