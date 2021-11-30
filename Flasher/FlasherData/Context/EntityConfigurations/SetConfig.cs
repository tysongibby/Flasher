using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlasherData.Models;

namespace FlasherData.Context.EntityConfigurations
{
    class SetConfig : IEntityTypeConfiguration<SetModel>
    {
        public void Configure(EntityTypeBuilder<SetModel> builder)
        {

            builder.HasData(
                    new List<SetModel>
                    {
                        new SetModel{ Id = 1, Title = "Set1", SupersetId = 1},
                        new SetModel{ Id = 2, Title = "Set2", SupersetId = 1},
                        new SetModel{ Id = 3, Title = "Set3", SupersetId = 1},
                        new SetModel{ Id = 4, Title = "Set4", SupersetId = 1},
                        new SetModel{ Id = 5, Title = "Set5", SupersetId = 2},
                        new SetModel{ Id = 6, Title = "Set6", SupersetId = 2},
                        new SetModel{ Id = 7, Title = "Set7", SupersetId = 2},
                        new SetModel{ Id = 8, Title = "Set8", SupersetId = 2}
                    }
                );

        }

    }
}
