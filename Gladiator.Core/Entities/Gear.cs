using Gladiator.Core.Entities.Base;

namespace Gladiator.Core.Entities
{
    public class Gear : BaseEntityWithName
    {
        public int Damage { get; set; }
        public int Armor { get; set; }
        public int Durability { get; set; }

        public int Slots { get; set; }
        public int Weight { get; set; }

        public Stats? StatModifiersPoints { get; set; }
        public Stats? StatModifiersPercent { get; set; }

        public int GladiatorId { get; set; }
        public Gladiator? Gladiator { get; set; }
    }
}
