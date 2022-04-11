using Gladiator.Core.Entities.Base;

namespace Gladiator.Core.Entities
{
    public class Arena : BaseEntityWithName
    {

        // owner
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public ICollection<Player> Players { get; set; }
        public ICollection<School>? Schools { get; set; }
        public ICollection<Gladiator>? Gladiators { get; set; }
    }
}
