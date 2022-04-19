using Gladiator.Core.Entities.Base;

namespace Gladiator.Core.Entities
{
    public class Stats : BaseEntity
    {
        public int Constitution { get; set; } // health and regeneration
        public int Strength { get; set; } // damage and blocking chance
        public int Dexterity { get; set; } // increase chance of hitting/double/critical opponent
        public int Agility { get; set; } // decrease chance of opponent hitting/double/critical
        public int Intelligence { get; set; } // learning (experience), increase critical hit chance (decrease opponents chance)
    }
}
