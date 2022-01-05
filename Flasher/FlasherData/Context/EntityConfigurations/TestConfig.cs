using FlasherData.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlasherData.Context.EntityConfigurations
{
    class TestConfig : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {

            builder.HasData(
                    new List<Test>
                    {
                        new Test{ Id = 1, Name = "Test_1", SubjectId = 1},
                        new Test{ Id = 2, Name = "Test_2", SubjectId = 2},
                        new Test{ Id = 3, Name = "Test_3", SubjectId = 3},
                        new Test{ Id = 4, Name = "Test_4", SubjectId = 4}//,
                        //new Test{ Id = 5, Name = "Test_5", SubjectId = 5},
                        //new Test{ Id = 6, Name = "Test_6", SubjectId = 6},
                        //new Test{ Id = 7, Name = "Test_7", SubjectId = 7},
                        //new Test{ Id = 8, Name = "Test_8", SubjectId = 8},
                    }
                );

        }
    }
}
