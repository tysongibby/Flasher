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
    class CategoryDmConfig : IEntityTypeConfiguration<CategoryDm>
    {
        public void Configure(EntityTypeBuilder<CategoryDm> builder)
        {

            builder.HasData(
                    new List<CategoryDm>
                    {
                        new CategoryDm{ Id = 1, Title = "Category1", SubjectDmId = 1},
                        new CategoryDm{ Id = 2, Title = "Category2", SubjectDmId = 1},
                        new CategoryDm{ Id = 3, Title = "Category3", SubjectDmId = 1},
                        new CategoryDm{ Id = 4, Title = "Category4", SubjectDmId = 1},
                        new CategoryDm{ Id = 5, Title = "Category5", SubjectDmId = 2},
                        new CategoryDm{ Id = 6, Title = "Category6", SubjectDmId = 2},
                        new CategoryDm{ Id = 7, Title = "Category7", SubjectDmId = 2},
                        new CategoryDm{ Id = 8, Title = "Category8", SubjectDmId = 2}
                    }
                );

        }

    }
}
