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
                        new Category{ Id = 1, Name = "Category1", SubjectId = 1},
                        new Category{ Id = 2, Name = "Category2", SubjectId = 1},
                        new Category{ Id = 3, Name = "Category3", SubjectId = 1},
                        new Category{ Id = 4, Name = "Category4", SubjectId = 1},
                        new Category{ Id = 5, Name = "Category5", SubjectId = 2},
                        new Category{ Id = 6, Name = "Category6", SubjectId = 2},
                        new Category{ Id = 7, Name = "Category7", SubjectId = 2},
                        new Category{ Id = 8, Name = "Category8", SubjectId = 2}
                    }
                );

        }

    }
}
