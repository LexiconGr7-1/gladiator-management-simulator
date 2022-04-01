using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gladiator.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gladiator.Infrastructure.ApplicationData.Data
{
    public class GladiatorContext : DbContext
    {
        public GladiatorContext(DbContextOptions<GladiatorContext> options) : base(options) { }

        public DbSet<Core.Entities.Gladiator> Gladiators { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Arena> Arenas { get; set; }
    }
}
