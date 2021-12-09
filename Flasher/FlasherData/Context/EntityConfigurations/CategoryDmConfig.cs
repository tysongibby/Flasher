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
                        new CategoryDm{ Id = 1, Name = "Category1", SubjectId = 1},
                        new CategoryDm{ Id = 2, Name = "Category2", SubjectId = 1},
                        new CategoryDm{ Id = 3, Name = "Category3", SubjectId = 1},
                        new CategoryDm{ Id = 4, Name = "Category4", SubjectId = 1},
                        new CategoryDm{ Id = 5, Name = "Category5", SubjectId = 2},
                        new CategoryDm{ Id = 6, Name = "Category6", SubjectId = 2},
                        new CategoryDm{ Id = 7, Name = "Category7", SubjectId = 2},
                        new CategoryDm{ Id = 8, Name = "Category8", SubjectId = 2}
                    }
                );

        }

    }
}
