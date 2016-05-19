﻿using Microsoft.Data.Entity;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Aviokompanija.Models
{
    class AviokompanijaDbContext : DbContext
    {
        public DbSet<Administrator> Administratori { get; set; }
        public DbSet<Avion> Avioni { get; set; }
        public DbSet<Kupac> Kupci { get; set; }
        public DbSet<Let> Letovi { get; set; }
        public DbSet<Uposlenik> Uposlenici { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databaseFilePath = "AviokompanijaBaza.db";
            try
            {
                databaseFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, databaseFilePath);
            }
            catch (InvalidOperationException) { }

            optionsBuilder.UseSqlite($"Data source={databaseFilePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}