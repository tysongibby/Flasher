using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlasherApi.Data.Models;

namespace FlasherApi.Data.EntityConfigurations
{
    class SupersetConfig : IEntityTypeConfiguration<Superset>
    {
        public void Configure(EntityTypeBuilder<Superset> builder)
        {

            builder.HasData(
                    new List<Superset>
                    {
                        new Superset{ Id = 1, Title = "Superset1"},
                        new Superset{ Id = 2, Title = "Superset2"},
                        new Superset{ Id = 3, Title = "Superset3"},
                        new Superset{ Id = 4, Title = "Superset4"},
                        new Superset{ Id = 5, Title = "Superset5"},
                        new Superset{ Id = 6, Title = "Superset6"},
                        new Superset{ Id = 7, Title = "Superset7"},
                        new Superset{ Id = 8, Title = "Superset8"}
                    }
                );

        }

    }
}
