﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using HiMVC.Models;
using Microsoft.Data.Entity.Infrastructure;
using System.Configuration;

namespace HiMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions contextOptions)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //var connectionString = "Server=(localdb)\\mssqllocaldb;Database=DataDb;Trusted_Connection=True;MultipleActiveResultSets=true";
            var connectionString = Startup.ConfigurationStatic["Data:DefaultConnection:ConnectionString"];

            builder.UseSqlServer(connectionString);
            base.OnConfiguring(builder);
        }

    }
}