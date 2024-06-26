﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CodeCone.Ducks.Models;

namespace CodeCone.Ducks.Data
{
    public class CodeConeDucksContext : DbContext
    {
        public CodeConeDucksContext (DbContextOptions<CodeConeDucksContext> options)
            : base(options)
        {
        }

        public DbSet<CodeCone.Ducks.Models.Ticket> Tickets { get; set; } = default!;
        public DbSet<CodeCone.Ducks.Models.User> Users { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer("Server=localhost;Initial Catalog=CodeConeDucks;Integrated Security=True;Multiple Active Result Sets=True;Trust Server Certificate=True;Command Timeout=300");
        public DbSet<CodeCone.Ducks.Models.Jar> Jar { get; set; } = default!;

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>()
        //        .HasIndex(u => u.UserName)
        //        .IsUnique();
            
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
