using Gladiator.Core.Entities.Base;

namespace Gladiator.Core.Entities
{
    public class School : BaseEntityWithName
    {
        public Player Player { get; set; }

        public ICollection<Gladiator> Gladiators { get; set; }
    }
}
