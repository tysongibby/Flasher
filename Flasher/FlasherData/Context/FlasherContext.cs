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

        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<Flashcard> Flashcards { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Subject>(new SubjectConfig());
            modelBuilder.ApplyConfiguration<Category>(new CategoryConfig());
            modelBuilder.ApplyConfiguration<Flashcard>(new FlashcardConfig());
        }

        
    }
}
