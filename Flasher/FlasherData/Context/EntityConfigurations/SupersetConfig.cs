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
    class SupersetConfig : IEntityTypeConfiguration<SupersetModel>
    {
        public void Configure(EntityTypeBuilder<SupersetModel> builder)
        {

            builder.HasData(
                    new List<SupersetModel>
                    {
                        new SupersetModel{ Id = 1, Title = "Superset1"},
                        new SupersetModel{ Id = 2, Title = "Superset2"},
                        new SupersetModel{ Id = 3, Title = "Superset3"},
                        new SupersetModel{ Id = 4, Title = "Superset4"},
                        new SupersetModel{ Id = 5, Title = "Superset5"},
                        new SupersetModel{ Id = 6, Title = "Superset6"},
                        new SupersetModel{ Id = 7, Title = "Superset7"},
                        new SupersetModel{ Id = 8, Title = "Superset8"}
                    }
                );

        }

    }
}
