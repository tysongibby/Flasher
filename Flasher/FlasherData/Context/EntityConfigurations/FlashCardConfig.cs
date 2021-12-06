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
    class FlashCardConfig : IEntityTypeConfiguration<FlashCardDm>
    {
        public void Configure(EntityTypeBuilder<FlashCardDm> builder)
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
                new List<FlashCardDm>
                {
                                new FlashCardDm{ Id = 1, Title = "FlashCard1", Front = "Front1", Back = "Back1", SubjectDmId = 1, CategoryDmId = 1},
                                new FlashCardDm{ Id = 2, Title = "FlashCard2", Front = "Front2", Back = "Back2", SubjectDmId = 1, CategoryDmId = 1},
                                new FlashCardDm{ Id = 3, Title = "FlashCard3", Front = "Front3", Back = "Back3", SubjectDmId = 1, CategoryDmId = 2},
                                new FlashCardDm{ Id = 4, Title = "FlashCard4", Front = "Front4", Back = "Back4", SubjectDmId = 1, CategoryDmId = 2},
                                new FlashCardDm{ Id = 5, Title = "FlashCard5", Front = "Front5", Back = "Back5", SubjectDmId = 2, CategoryDmId = 3},
                                new FlashCardDm{ Id = 6, Title = "FlashCard6", Front = "Front5", Back = "Back6", SubjectDmId = 2, CategoryDmId = 3},
                                new FlashCardDm{ Id = 7, Title = "FlashCard7", Front = "Front7", Back = "Back7", SubjectDmId = 2, CategoryDmId = 4},
                                new FlashCardDm{ Id = 8, Title = "FlashCard8", Front = "Front8", Back = "Back8", SubjectDmId = 2, CategoryDmId = 4}
                }
            );

        }

    }
}
