using Gladiator.Core.Entities.Base;

namespace Gladiator.Core.Entities
{
    public class Arena : BaseEntityWithName
    {
        public ICollection<School> Schools { get; set; }
        public ICollection<Gladiator> Gladiators { get; set; }
    }
}
