using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlasherApi.Data.Models;

namespace Flasher.Server.Data.EntityConfigurations
{
    class FlashCardConfig : IEntityTypeConfiguration<FlashCard>
    {
        public void Configure(EntityTypeBuilder<FlashCard> builder)
        {
            builder.Property(c => c.Id)
                   .IsRequired();

            builder.Property(c => c.Title)
                   .IsRequired();

            builder.Property(c => c.Front)
                   .IsRequired();

            builder.Property(c => c.Back)
                   .IsRequired();


            builder.HasData(
                    new List<FlashCard>
                    {
                        new FlashCard{ Id = 1, Title = "Title1", Front = "Front_1", Back = "Back_1"},
                        new FlashCard{ Id = 2, Title = "Title2", Front = "Front_2", Back = "Back_2"},
                        new FlashCard{ Id = 3, Title = "Title3", Front = "Front_3", Back = "Back_3"},
                        new FlashCard{ Id = 4, Title = "Title4", Front = "Front_4", Back = "Back_4"}
                    }
                );

            
        }

       
    }
}
