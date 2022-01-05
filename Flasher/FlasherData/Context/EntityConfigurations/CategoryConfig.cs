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
                        new Category{ Id = 1, Name = "Category_1", SubjectId = 1},
                        new Category{ Id = 2, Name = "Category_2", SubjectId = 1},
                        new Category{ Id = 3, Name = "Category_3", SubjectId = 1},
                        new Category{ Id = 4, Name = "Category_4", SubjectId = 1},
                        new Category{ Id = 5, Name = "Category_5", SubjectId = 2},
                        new Category{ Id = 6, Name = "Category_6", SubjectId = 2},
                        new Category{ Id = 7, Name = "Category_7", SubjectId = 2},
                        new Category{ Id = 8, Name = "Category_8", SubjectId = 2}
                    }
                );

        }

    }
}
