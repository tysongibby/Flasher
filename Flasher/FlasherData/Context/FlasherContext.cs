using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlasherData.DataModels;
using FlasherData.Context.EntityConfigurations;
using FlasherData.Repositories;

namespace FlasherData.Context
{
    public class FlasherContext : DbContext
    {
        public FlasherContext()
        {
        }
        public FlasherContext(IConfiguration configuration, DbContextOptions<FlasherContext> options) : base(options)
        {
            Configuration = configuration;        
        }

        public IConfiguration Configuration { get; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Flashcard> Flashcards { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Subject>(new SubjectConfig());
            modelBuilder.ApplyConfiguration<Category>(new CategoryConfig());
            modelBuilder.ApplyConfiguration<Flashcard>(new FlashcardConfig());
            modelBuilder.ApplyConfiguration<Question>(new QuestionConfig());
            modelBuilder.ApplyConfiguration<Test>(new TestConfig());
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlite(Configuration.GetConnectionString("FlasherDb"));
        //}
    }
}
