using Gladiator.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Gladiator.Infrastructure.Data.Data
{
    public class GladiatorContext : DbContext
    {
        public GladiatorContext(DbContextOptions<GladiatorContext> options) : base(options) { }
        
        public DbSet<Player> Player { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
        }

    }
}
