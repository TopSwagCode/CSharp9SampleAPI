﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProductAPI.Databases.Models;

namespace ProductAPI.Databases
{
    public class AppDbContext : DbContext
    {
        protected AppDbContext(DbContextOptions options) : base(options) { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : this((DbContextOptions)options)
        {
        }

        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            //Property Configurations
            modelBuilder.Entity<Product>().HasKey(x => x.Uid);
        }
    }
}
