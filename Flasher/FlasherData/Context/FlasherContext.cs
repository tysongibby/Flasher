using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlasherData.Models;
using FlasherData.Context.EntityConfigurations;

namespace FlasherData.Context
{
    public class FlasherContext : DbContext
    {
        public FlasherContext()
        { }
        public FlasherContext(DbContextOptions<FlasherContext> options) : base(options)
        { }

        public virtual DbSet<SupersetModel> Supersets { get; set; }
        public virtual DbSet<SetModel> Sets { get; set; }
        public virtual DbSet<FlashCardModel> FlashCards { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<SupersetModel>(new SupersetConfig());
            modelBuilder.ApplyConfiguration<SetModel>(new SetConfig());
            modelBuilder.ApplyConfiguration<FlashCardModel>(new FlashCardConfig());
        }

        
    }
}
