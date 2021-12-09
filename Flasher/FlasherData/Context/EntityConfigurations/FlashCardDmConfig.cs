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
    class FlashcardDmConfig : IEntityTypeConfiguration<FlashcardDm>
    {
        public void Configure(EntityTypeBuilder<FlashcardDm> builder)
        {
            //builder.HasKey(c => c.Id);

            //builder.Property(c => c.Title)
            //       .IsRequired();

            //builder.Property(c => c.Front)
            //       .IsRequired();

            //builder.Property(c => c.Back)
            //       .IsRequired();

            //builder.Property(fc => fc.SubjectDm)
            //       .IsRequired();

            //builder.Property(fc => fc.CategoryDm);

            builder.HasData(
                    new List<FlashcardDm>
                    {
                                    new FlashcardDm{ Id = 1, Name = "Flashcard1", Front = "Front1", Back = "Back1", CategoryId = 1},
                                    new FlashcardDm{ Id = 2, Name = "Flashcard2", Front = "Front2", Back = "Back2", CategoryId = 1},
                                    new FlashcardDm{ Id = 3, Name = "Flashcard3", Front = "Front3", Back = "Back3", CategoryId = 2},
                                    new FlashcardDm{ Id = 4, Name = "Flashcard4", Front = "Front4", Back = "Back4", CategoryId = 2},
                                    new FlashcardDm{ Id = 5, Name = "Flashcard5", Front = "Front5", Back = "Back5", CategoryId = 3},
                                    new FlashcardDm{ Id = 6, Name = "Flashcard6", Front = "Front5", Back = "Back6", CategoryId = 3},
                                    new FlashcardDm{ Id = 7, Name = "Flashcard7", Front = "Front7", Back = "Back7", CategoryId = 4},
                                    new FlashcardDm{ Id = 8, Name = "Flashcard8", Front = "Front8", Back = "Back8", CategoryId = 4}
                    }
                );

        }

    }
}
