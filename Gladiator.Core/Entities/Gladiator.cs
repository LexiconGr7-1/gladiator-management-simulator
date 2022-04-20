using System.Collections;
using Gladiator.Core.Entities.Base;

namespace Gladiator.Core.Entities
{
    public class Gladiator : BaseEntityWithName
    {
        public Gladiator() { }

        public int Health { get; set; }
        public int Experience { get; set; }

        public int StatsId { get; set; }
        public Stats? Stats { get; set; }

        public int StatUpdatesId { get; set; }
        public Stats? StatUpdates { get; set; }

        public int ArenaId { get; set; }
        public Arena? Arena { get; set; }

        public int SchoolId { get; set; }
        public School? School { get; set; }

        public int PlayerId { get; set; }
        public Player? Player { get; set; }

        public ICollection<Gear>? Gear { get; set; }

        //derived
        public int Strength =>
            (int) ((Stats?.Strength 
              + Gear?.Sum(g => g?.StatModifiersPoints?.Strength)) 
             * (1.0 + Gear?.Sum(g => g?.StatModifiersPercent?.Strength) / 100.0) 
             ?? 1);

        public int MaxGearSlots => (int) Math.Log2(Strength);
        public int OccupiedGearSlots => Gear?.Sum(g => g?.Slots) ?? 0;

        public int MaxGearWeight => Strength;
        public int GearWeight => Gear?.Sum(g => g?.Weight) ?? 1;

        public double SpeedModifier =>
            1.0 - GearWeight * 1.0 / MaxGearWeight;

        public int Armour => Gear?.Sum(g => g?.Armor) + Strength ?? 0;
        public int Damage => Gear?.Sum(g => g?.Damage) + Strength ?? 0;
    }
}
