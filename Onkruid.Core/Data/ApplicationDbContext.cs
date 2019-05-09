using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Onkruid.Core.Models;

namespace Onkruid.Core.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //initialiseren van tabellen (properties)
        public DbSet<Familie> Familie { get; set; }
        public DbSet<Gebruik> Gebruik { get; set; }
        public DbSet<Onkruid_Naam> Onkruid_Naam { get; set; }

        //override methods
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //composite key
            builder.Entity<Onkruid_Naam>().HasKey(on => new { on.Familie_Naam, on.Gebruik_Nr });
        }
    }
}
