using Gladiator.Core.Entities.Base;

namespace Gladiator.Core.Entities
{
    public class School : BaseEntityWithName
    {
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int ArenaId { get; set; }
        public Arena Arena { get; set; }

        public ICollection<Gladiator> Gladiators { get; set; }
    }
}
