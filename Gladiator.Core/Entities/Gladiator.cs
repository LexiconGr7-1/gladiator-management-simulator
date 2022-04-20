using Gladiator.Core.Entities.Base;

namespace Gladiator.Core.Entities
{
    public class Gladiator : BaseEntityWithName
    {
        public int Health { get; set; }
        public int Experience { get; set; }

        public int StatsId { get; set; }
        public Stats? Stats { get; set; }

        public int StatUpdatesId { get; set; }
        public Stats? StatUpdates { get; set; }

        public int SchoolId { get; set; }
        public School? School { get; set; }

        public int PlayerId { get; set; }
        public Player? Player { get; set; }

        public ICollection<Gear>? Gear { get; set; }

        public ICollection<BattleLog>? Log { get; set; }

        //derived
        public int? ArenaId => School?.ArenaId;
        public Arena? Arena => School?.Arena;
        
        public int Strength =>
            (int)((Stats?.Strength ?? 0 + GearPointsStrength)
                   * (1 + GearPercentStrength * 0.01));
        public int GearPointsStrength => Gear?.Sum(g => g.StatModifiersPoints?.Strength) ?? 0;
        public int GearPercentStrength => Gear?.Sum(g => g.StatModifiersPercent?.Strength) ?? 0;

        public int MaxGearSlots => (int)Math.Log2(Strength);
        public int OccupiedGearSlots => Gear?.Sum(g => g.Slots) ?? 0;
        public int MaxGearWeight => Strength;
        public int GearWeight => Gear?.Sum(g => g.Weight) ?? 0;
        public double GearWeightRatio => 1.0 - GearWeight * 1.0 / MaxGearWeight;

        public int Armour => Gear?.Sum(g => g.Armor) ?? 0;
        public int Damage => Gear?.Sum(g => g.Damage) ?? 0;

        public int BlockingStrength => (int)((Armour + Strength) * GearWeightRatio);
        public int AttackStrength => (int)((Damage + Strength) * GearWeightRatio);
        public double BlockChance(int opponentDexterity) => Stats?.Agility ?? 1.0 / opponentDexterity;
        public double HitChance(int opponentAgility) => Stats?.Dexterity ?? 1.0 / opponentAgility;
    }
}
