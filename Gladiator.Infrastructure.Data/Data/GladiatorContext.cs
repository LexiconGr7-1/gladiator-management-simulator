using Gladiator.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gladiator.Infrastructure.Data.Data
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
