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
                                    new FlashcardDm{ Id = 1, Title = "Flashcard1", Front = "Front1", Back = "Back1", CategoryDmId = 1},
                                    new FlashcardDm{ Id = 2, Title = "Flashcard2", Front = "Front2", Back = "Back2", CategoryDmId = 1},
                                    new FlashcardDm{ Id = 3, Title = "Flashcard3", Front = "Front3", Back = "Back3", CategoryDmId = 2},
                                    new FlashcardDm{ Id = 4, Title = "Flashcard4", Front = "Front4", Back = "Back4", CategoryDmId = 2},
                                    new FlashcardDm{ Id = 5, Title = "Flashcard5", Front = "Front5", Back = "Back5", CategoryDmId = 3},
                                    new FlashcardDm{ Id = 6, Title = "Flashcard6", Front = "Front5", Back = "Back6", CategoryDmId = 3},
                                    new FlashcardDm{ Id = 7, Title = "Flashcard7", Front = "Front7", Back = "Back7", CategoryDmId = 4},
                                    new FlashcardDm{ Id = 8, Title = "Flashcard8", Front = "Front8", Back = "Back8", CategoryDmId = 4}
                    }
                );

        }

    }
}
