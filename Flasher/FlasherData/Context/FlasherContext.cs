using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlasherData.DataModels;
using FlasherData.Context.EntityConfigurations;

namespace FlasherData.Context
{
    public class FlasherContext : DbContext
    {
        public FlasherContext()
        { }
        public FlasherContext(DbContextOptions<FlasherContext> options) : base(options)
        { }

        public virtual DbSet<SubjectDm> SubjectDms { get; set; }
        public virtual DbSet<CategoryDm> CategoryDms { get; set; }
        public virtual DbSet<FlashcardDm> FlashcardDms { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<SubjectDm>(new SubjectDmConfig());
            modelBuilder.ApplyConfiguration<CategoryDm>(new CategoryDmConfig());
            modelBuilder.ApplyConfiguration<FlashcardDm>(new FlashcardDmConfig());
        }

        
    }
}
