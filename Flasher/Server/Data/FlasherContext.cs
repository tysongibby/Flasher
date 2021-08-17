﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flasher.Shared.Data.Models;
using Flasher.Server.Data.EntityConfigurations;

namespace Flasher.Server.Data
{
    public class FlasherContext : DbContext
    {
        public FlasherContext()
        { }
        public FlasherContext(DbContextOptions<FlasherContext> options) : base(options)
        { }

        public virtual DbSet<FlashCard> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<FlashCard>(new FlashCardConfig());
        }

        
    }
}
