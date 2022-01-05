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
    class FlashcardConfig : IEntityTypeConfiguration<Flashcard>
    {
        public void Configure(EntityTypeBuilder<Flashcard> builder)
        {
            //builder.HasKey(c => c.Id);

            //builder.Property(c => c.Name)
            //       .IsRequired();

            //builder.Property(c => c.Front)
            //       .IsRequired();

            //builder.Property(c => c.Back)
            //       .IsRequired();

            //builder.Property(fc => fc.Subject)
            //       .IsRequired();

            //builder.Property(fc => fc.Category);

            builder.HasData(
                    new List<Flashcard>
                    {
                                    new Flashcard{ Id = 1, Name = "Flashcard_1", Front = "Front_1", Back = "Back_1", CategoryId = 1},
                                    new Flashcard{ Id = 2, Name = "Flashcard_2", Front = "Front_2", Back = "Back_2", CategoryId = 1},
                                    new Flashcard{ Id = 3, Name = "Flashcard_3", Front = "Front_3", Back = "Back_3", CategoryId = 2},
                                    new Flashcard{ Id = 4, Name = "Flashcard_4", Front = "Front_4", Back = "Back_4", CategoryId = 2},
                                    new Flashcard{ Id = 5, Name = "Flashcard_5", Front = "Front_5", Back = "Back_5", CategoryId = 3},
                                    new Flashcard{ Id = 6, Name = "Flashcard_6", Front = "Front_5", Back = "Back_6", CategoryId = 3},
                                    new Flashcard{ Id = 7, Name = "Flashcard_7", Front = "Front_7", Back = "Back_7", CategoryId = 4},
                                    new Flashcard{ Id = 8, Name = "Flashcard_8", Front = "Front_8", Back = "Back_8", CategoryId = 4}
                    }
                );

        }

    }
}
