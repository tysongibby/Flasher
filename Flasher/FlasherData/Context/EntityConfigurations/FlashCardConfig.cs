using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlasherData.Models;

namespace FlasherData.Context.EntityConfigurations
{
    class FlashCardConfig : IEntityTypeConfiguration<FlashCardModel>
    {
        public void Configure(EntityTypeBuilder<FlashCardModel> builder)
        {
            //builder.HasKey(c => c.Id);

            //builder.Property(c => c.Title)
            //       .IsRequired();

            //builder.Property(c => c.Front)
            //       .IsRequired();

            //builder.Property(c => c.Back)
            //       .IsRequired();

            //builder.Property(fc => fc.Superset)
            //       .IsRequired();

            //builder.Property(fc => fc.Set);

            builder.HasData(
                new List<FlashCardModel>
                {
                                new FlashCardModel{ Id = 1, Title = "FlashCard1", Front = "Front1", Back = "Back1", SupersetId = 1, SetId = 1},
                                new FlashCardModel{ Id = 2, Title = "FlashCard2", Front = "Front2", Back = "Back2", SupersetId = 1, SetId = 1},
                                new FlashCardModel{ Id = 3, Title = "FlashCard3", Front = "Front3", Back = "Back3", SupersetId = 1, SetId = 2},
                                new FlashCardModel{ Id = 4, Title = "FlashCard4", Front = "Front4", Back = "Back4", SupersetId = 1, SetId = 2},
                                new FlashCardModel{ Id = 5, Title = "FlashCard5", Front = "Front5", Back = "Back5", SupersetId = 2, SetId = 3},
                                new FlashCardModel{ Id = 6, Title = "FlashCard6", Front = "Front5", Back = "Back6", SupersetId = 2, SetId = 3},
                                new FlashCardModel{ Id = 7, Title = "FlashCard7", Front = "Front7", Back = "Back7", SupersetId = 2, SetId = 4},
                                new FlashCardModel{ Id = 8, Title = "FlashCard8", Front = "Front8", Back = "Back8", SupersetId = 2, SetId = 4}
                }
            );

        }

    }
}
