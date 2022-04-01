using Gladiator.Core.Entities.Base;

namespace Gladiator.Core.Entities
{
    public class School : BaseEntityWithName
    {
        public List<Gladiator> Gladiators { get; set; }
        public Player Player { get; set; }
    }
}
