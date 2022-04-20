using Gladiator.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gladiator.Infrastructure.Data.Data
{
    public class GladiatorContext : DbContext
    {
        public GladiatorContext(DbContextOptions<GladiatorContext> options) : base(options) { }
        
        public DbSet<Player> Player { get; set; }
        public DbSet<Core.Entities.Gladiator> Gladiator { get; set; }
        public DbSet<Arena> Arena { get; set; }
        public DbSet<School> School { get; set; }
        public DbSet<Stats> Stats { get; set; }
        public DbSet<Gear> Gear { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gear>()
                .HasOne(g => g.StatModifiersPoints)
                .WithOne(s => s.StatModifiersPoints)
                .HasForeignKey<Gear>(g => g.StatModifiersPointsId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Gear>()
                .HasOne(g => g.StatModifiersPercent)
                .WithOne(s => s.StatModifiersPercent)
                .HasForeignKey<Gear>(g => g.StatModifiersPercentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Core.Entities.Gladiator>()
                .HasOne(g => g.Stats)
                .WithOne(s => s.StatGladiator)
                .HasForeignKey<Core.Entities.Gladiator>(g => g.StatsId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Core.Entities.Gladiator>()
                .HasOne(g => g.StatUpdates)
                .WithOne(s => s.StatUpdates)
                .HasForeignKey<Core.Entities.Gladiator>(g => g.StatUpdatesId)
                .OnDelete(DeleteBehavior.NoAction);

            // ---  populate database ---

            modelBuilder.Entity<Player>().HasData(
                new Player { Id = 1, Name = "Player 1", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow}
            );

            modelBuilder.Entity<Core.Entities.Gladiator>().HasData(
                new Core.Entities.Gladiator()
                {
                    Id = 1, Name = "Gladiator 1",
                    PlayerId = 1, ArenaId = 1, SchoolId = 1, 
                    Health = 1, Experience = 0,
                    StatsId = 1, StatUpdatesId = 2,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                }
            );

            modelBuilder.Entity<Arena>().HasData(
                new Arena { Id = 1, Name = "Arena 1", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow}
            );

            modelBuilder.Entity<School>().HasData(
                new School
                {
                    Id = 1, Name = "Arena 1", 
                    ArenaId = 1, PlayerId = 1, 
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                }
            );

            modelBuilder.Entity<Gear>().HasData(
                new Gear
                {
                    Id = 1, Name = "Gear 1", 
                    GladiatorId = 1, StatModifiersPercentId = 3, StatModifiersPointsId = 4,
                    Armor = 1, Damage = 1, Durability = 1, Slots = 1, Weight = 1,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                }
            );

            modelBuilder.Entity<Stats>().HasData(
                new Stats
                {
                    Id = 1,
                    Agility = 1, Constitution = 1, Dexterity = 1, Intelligence = 1, Strength = 1,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                },
                new Stats
                {
                    Id = 2,
                    Agility = 2, Constitution = 2, Dexterity = 2, Intelligence = 2, Strength = 2,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                },
                new Stats
                {
                    Id = 3,
                    Agility = 3, Constitution = 3, Dexterity = 3, Intelligence = 3, Strength = 3,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                },
                new Stats
                {
                    Id = 4,
                    Agility = 4, Constitution = 4, Dexterity = 4, Intelligence = 4, Strength = 4,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
