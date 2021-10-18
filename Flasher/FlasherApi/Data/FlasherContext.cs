using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlasherApi.Data.Models;
using FlasherApi.Data.EntityConfigurations;

namespace FlasherApi.Data
{
    public class FlasherContext : DbContext
    {
        public FlasherContext()
        { }
        public FlasherContext(DbContextOptions<FlasherContext> options) : base(options)
        { }

        public virtual DbSet<Superset> Supersets { get; set; }
        public virtual DbSet<Set> Sets { get; set; }
        public virtual DbSet<FlashCard> FlashCards { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Superset>(new SupersetConfig());
            modelBuilder.ApplyConfiguration<Set>(new SetConfig());
            modelBuilder.ApplyConfiguration<FlashCard>(new FlashCardConfig());
        }

        
    }
}
