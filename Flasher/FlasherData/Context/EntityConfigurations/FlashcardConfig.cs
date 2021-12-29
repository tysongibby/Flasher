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
                                    new Flashcard{ Id = 1, Name = "Flashcard1", Front = "Front1", Back = "Back1", CategoryId = 1},
                                    new Flashcard{ Id = 2, Name = "Flashcard2", Front = "Front2", Back = "Back2", CategoryId = 1},
                                    new Flashcard{ Id = 3, Name = "Flashcard3", Front = "Front3", Back = "Back3", CategoryId = 2},
                                    new Flashcard{ Id = 4, Name = "Flashcard4", Front = "Front4", Back = "Back4", CategoryId = 2},
                                    new Flashcard{ Id = 5, Name = "Flashcard5", Front = "Front5", Back = "Back5", CategoryId = 3},
                                    new Flashcard{ Id = 6, Name = "Flashcard6", Front = "Front5", Back = "Back6", CategoryId = 3},
                                    new Flashcard{ Id = 7, Name = "Flashcard7", Front = "Front7", Back = "Back7", CategoryId = 4},
                                    new Flashcard{ Id = 8, Name = "Flashcard8", Front = "Front8", Back = "Back8", CategoryId = 4}
                    }
                );

        }

    }
}
