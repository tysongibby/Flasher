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
    class FlashCardSetConfig : IEntityTypeConfiguration<FlashCardSet>
    {
        public void Configure(EntityTypeBuilder<FlashCardSet> builder)
        {
            builder.HasKey(c => c.Id);
            //builder.Property(c => c.Id)                   
            //       .IsRequired();

            builder.Property(c => c.Title)
                   .IsRequired();

            builder.HasOne(c => c.FlashCardSuperSet);


            // uncomment to add starting data for FlashCardSet object
            //builder.HasData(
            //        new List<FlashCardSet>
            //        {
            //            //add starting data here
            //        }
            //    );

            
        }

       
    }
}
