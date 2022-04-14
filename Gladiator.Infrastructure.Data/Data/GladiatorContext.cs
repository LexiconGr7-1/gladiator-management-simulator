using Gladiator.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using System.Threading.Tasks;

namespace Gladiator.Infrastructure.Data.Data
{
    public class GladiatorContext : DbContext
    {
        public GladiatorContext(DbContextOptions<GladiatorContext> options) : base(options) { }

        public DbSet<Core.Entities.Gladiator> Gladiators { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Arena> Arenas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Core.Entities.Gladiator>().ToTable("Gladiator");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<School>().ToTable("Schools");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Player>().ToTable("Gladiator");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Arena>().ToTable("Arenas");
        }
    }
}
