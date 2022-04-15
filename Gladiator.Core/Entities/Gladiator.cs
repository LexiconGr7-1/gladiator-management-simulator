using Gladiator.Core.Entities.Base;

namespace Gladiator.Core.Entities
{
    public class Gladiator : BaseEntityWithName
    {
        public int Health { get; set; }
        public int Strength { get; set; }

        public int? ArenaId { get; set; }
        public Arena? Arena { get; set; }

        public int? SchoolId { get; set; }
        public School? School { get; set; }

        public int? PlayerId { get; set; }
        public Player? Player { get; set; }

    }
}
