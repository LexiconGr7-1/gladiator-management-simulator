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
            modelBuilder.Entity<Player>()
                .HasMany(p => p.OwnedArenas)
                .WithMany(s => s.Owners);

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
                new Player { Id = 1, Name = "Player 1", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Player { Id = 2, Name = "Player 2", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Player { Id = 3, Name = "Player 3", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Player { Id = 4, Name = "Player 4", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
            );

            modelBuilder.Entity<Core.Entities.Gladiator>().HasData(
                new Core.Entities.Gladiator()
                {
                    Id = 1, Name = "Gladiator 1", PlayerId = 1, SchoolId = 1, 
                    Health = 1, Experience = 1, StatsId = 1, StatUpdatesId = 2,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                },
                new Core.Entities.Gladiator()
                {
                    Id = 2, Name = "Gladiator 2", PlayerId = 1, SchoolId = 1, 
                    Health = 2, Experience = 2, StatsId = 3, StatUpdatesId = 4,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                },
                new Core.Entities.Gladiator()
                {
                    Id = 3, Name = "Gladiator 3", PlayerId = 1, SchoolId = 1, 
                    Health = 3, Experience = 3, StatsId = 5, StatUpdatesId = 6,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                },
                new Core.Entities.Gladiator()
                {
                    Id = 4, Name = "Gladiator 4", PlayerId = 2, SchoolId = 2, 
                    Health = 4, Experience = 4, StatsId = 7, StatUpdatesId = 8,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                },
                new Core.Entities.Gladiator()
                {
                    Id = 5, Name = "Gladiator 5", PlayerId = 2, SchoolId = 2, 
                    Health = 5, Experience = 5, StatsId = 9, StatUpdatesId = 10,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                },
                new Core.Entities.Gladiator()
                {
                    Id = 6, Name = "Gladiator 6", PlayerId = 2, SchoolId = 2, 
                    Health = 6, Experience = 6, StatsId = 11, StatUpdatesId = 12,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                },
                new Core.Entities.Gladiator()
                {
                    Id = 7, Name = "Gladiator 7", PlayerId = 3, SchoolId = 3, 
                    Health = 7, Experience = 7, StatsId = 13, StatUpdatesId = 14,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                },
                new Core.Entities.Gladiator()
                {
                    Id = 8, Name = "Gladiator 8", PlayerId = 3, SchoolId = 3, 
                    Health = 8, Experience = 8, StatsId = 15, StatUpdatesId = 16,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                },
                new Core.Entities.Gladiator()
                {
                    Id = 9, Name = "Gladiator 9", PlayerId = 3, SchoolId = 3, 
                    Health = 9, Experience = 9, StatsId = 17, StatUpdatesId = 18,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                },
                new Core.Entities.Gladiator()
                {
                    Id = 10, Name = "Gladiator 10", PlayerId = 4, SchoolId = 4, 
                    Health = 10, Experience = 10, StatsId = 19, StatUpdatesId = 20,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                },
                new Core.Entities.Gladiator()
                {
                    Id = 11, Name = "Gladiator 11", PlayerId = 4, SchoolId = 4, 
                    Health = 11, Experience = 11, StatsId = 21, StatUpdatesId = 22,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                },
                new Core.Entities.Gladiator()
                {
                    Id = 12, Name = "Gladiator 12", PlayerId = 4, SchoolId = 4, 
                    Health = 12, Experience = 12, StatsId = 23, StatUpdatesId = 24,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                }
            );

            modelBuilder.Entity<Arena>().HasData(
                new Arena { Id = 1, Name = "Arena 1", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow},
                new Arena { Id = 2, Name = "Arena 2", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow}
            );

            modelBuilder.Entity<School>().HasData(
                new School
                {
                    Id = 1, Name = "School 1", ArenaId = 1, PlayerId = 1,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                },
                new School
                {
                    Id = 2, Name = "School 2", ArenaId = 1, PlayerId = 2,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                },
                new School
                {
                    Id = 3, Name = "School 3", ArenaId = 2, PlayerId = 3,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                },
                new School
                {
                    Id = 4, Name = "School 4", ArenaId = 2, PlayerId = 4,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                }
            );

            modelBuilder.Entity<Gear>().HasData(
                new Gear
                {
                    Id = 1, Name = "Gear 1", Armor = 1, Damage = 1, Durability = 1, Slots = 1, Weight = 1,
                    GladiatorId = 1, StatModifiersPercentId = 25, StatModifiersPointsId = 26,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                },
                new Gear
                {
                    Id = 2, Name = "Gear 2", Armor = 2, Damage = 2, Durability = 2, Slots = 2, Weight = 2,
                    GladiatorId = 2, StatModifiersPercentId = 27, StatModifiersPointsId = 28,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                },
                new Gear
                {
                    Id = 3, Name = "Gear 3", Armor = 3, Damage = 3, Durability = 3, Slots = 3, Weight = 3,
                    GladiatorId = 3, StatModifiersPercentId = 29, StatModifiersPointsId = 30,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                },
                new Gear
                {
                    Id = 4, Name = "Gear 4", Armor = 4, Damage = 4, Durability = 4, Slots = 4, Weight = 4,
                    GladiatorId = 4, StatModifiersPercentId = 31, StatModifiersPointsId = 32,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                },
                new Gear
                {
                    Id = 5, Name = "Gear 5", Armor = 5, Damage = 5, Durability = 5, Slots = 5, Weight = 5,
                    GladiatorId = 5, StatModifiersPercentId = 33, StatModifiersPointsId = 34,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                },
                new Gear
                {
                    Id = 6, Name = "Gear 6", Armor = 6, Damage = 6, Durability = 6, Slots = 6, Weight = 6,
                    GladiatorId = 6, StatModifiersPercentId = 35, StatModifiersPointsId = 36,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                },
                new Gear
                {
                    Id = 7, Name = "Gear 7", Armor = 7, Damage = 7, Durability = 7, Slots = 7, Weight = 7,
                    GladiatorId = 7, StatModifiersPercentId = 37, StatModifiersPointsId = 38,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                },
                new Gear
                {
                    Id = 8, Name = "Gear 8", Armor = 8, Damage = 8, Durability = 8, Slots = 8, Weight = 8,
                    GladiatorId = 8, StatModifiersPercentId = 39, StatModifiersPointsId = 40,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                },
                new Gear
                {
                    Id = 9, Name = "Gear 9", Armor = 9, Damage = 9, Durability = 9, Slots = 9, Weight = 9,
                    GladiatorId = 9, StatModifiersPercentId = 41, StatModifiersPointsId = 42,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                },
                new Gear
                {
                    Id = 10, Name = "Gear 10", Armor = 10, Damage = 10, Durability = 10, Slots = 10, Weight = 10,
                    GladiatorId = 10, StatModifiersPercentId = 43, StatModifiersPointsId = 44,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                },
                new Gear
                {
                    Id = 11, Name = "Gear 11", Armor = 11, Damage = 11, Durability = 11, Slots = 11, Weight = 11,
                    GladiatorId = 11, StatModifiersPercentId = 45, StatModifiersPointsId = 46,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                },
                new Gear
                {
                    Id = 12, Name = "Gear 12", Armor = 12, Damage = 12, Durability = 12, Slots = 12, Weight = 12,
                    GladiatorId = 12, StatModifiersPercentId = 47, StatModifiersPointsId = 48,
                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                }
            );

            modelBuilder.Entity<Stats>().HasData(generateStats(48));
        }

        private Stats[] generateStats(int count)
        {
            var statsList = new List<Stats>();

            for (int i = 1; i <= count; i++)
            {
                statsList.Add(
                    new Stats
                    {
                        Id = i, 
                        Agility = i, 
                        Constitution = i, 
                        Dexterity = i, 
                        Intelligence = i, 
                        Strength = i, 
                        CreatedAt = DateTime.UtcNow, 
                        UpdatedAt = DateTime.UtcNow
                    });
            }

            return statsList.ToArray();
        }
    }
}
