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
    class QuestionConfig : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {

            builder.HasData(
                    new List<Question>
                    {
                        new Question{ Id = 1, Number = 1, AnsweredCorrectly = false, FlashcardId = 1, TestId = 1},
                        new Question{ Id = 2, Number = 2, AnsweredCorrectly = false, FlashcardId = 2, TestId = 2},
                        new Question{ Id = 3, Number = 3, AnsweredCorrectly = false, FlashcardId = 3, TestId = 3},
                        new Question{ Id = 4, Number = 4, AnsweredCorrectly = false, FlashcardId = 4, TestId = 4},
                        //new Question{ Id = 5, Number = 5, AnsweredCorrectly = false, FlashcardId = 5, TestId = 5},
                        //new Question{ Id = 6, Number = 6, AnsweredCorrectly = false, FlashcardId = 6, TestId = 6},
                        //new Question{ Id = 7, Number = 7, AnsweredCorrectly = false, FlashcardId = 7, TestId = 7},
                        //new Question{ Id = 8, Number = 8, AnsweredCorrectly = false, FlashcardId = 8, TestId = 8}
                    }
                );

        }
    }

}
