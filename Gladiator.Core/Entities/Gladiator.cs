using System.Collections;
using Gladiator.Core.Entities.Base;

namespace Gladiator.Core.Entities
{
    public class Gladiator : BaseEntityWithName
    {
        public Gladiator() { }

        public int Health { get; set; }
        public int Experience { get; set; }
        public int TotalExperience { get; set; }
        public Stats Stats { get; set; }
        public Stats StatUpdatesCount { get; set; }

        public int ArenaId { get; set; }
        public Arena Arena { get; set; }

        public int SchoolId { get; set; }
        public School School { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public ICollection<Gear> Gear { get; set; }

        // derived values
        public int Strength =>
            ((Stats.Strength
              + Gear.Sum(g => g.StatModifiersPoints?.Strength))
             * Gear.Sum(g => g.StatModifiersPercent?.Strength)
             / 100)
            ?? 0;

        public int MaxGearSlots => (int)Math.Log10(Strength);

        public int MaxGearWeight => Strength;

        public double SpeedModifier => 
            1.0 - Gear.Sum(g => g.Weight) / MaxGearWeight;

        public int Armour =>  Gear.Sum(g => g.Armor) + Strength / 10;
        public int Damage =>  Strength + Gear.Sum(g => g.Damage);
    }
}
