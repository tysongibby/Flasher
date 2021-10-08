using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlasherShared.Data.Models;

namespace Flasher.Server.Data.EntityConfigurations
{
    class FlashCardConfig : IEntityTypeConfiguration<FlashCard>
    {
        public void Configure(EntityTypeBuilder<FlashCard> builder)
        {
            builder.Property(c => c.Id)
                   .IsRequired();

            builder.Property(c => c.Front)
                   .IsRequired();


            builder.Property(c => c.Back)
                   .IsRequired();                   

            
            builder.HasData(
                    new List<FlashCard>
                    {
                        new FlashCard{ Id = 1, Front = "Front_1", Back = "Back_1"},
                        new FlashCard{ Id = 2, Front = "Front_2", Back = "Back_2"},
                        new FlashCard{ Id = 3, Front = "Front_3", Back = "Back_3"},
                        new FlashCard{ Id = 4, Front = "Front_4", Back = "Back_4"}
                    }
                );

            
        }

       
    }
}
