using System.Collections.Immutable;
using Gladiator.Core.Entities.Base;

namespace Gladiator.Core.Entities
{
    public class Arena : BaseEntityWithName
    {
        public ICollection<Player>? Owners { get; set; }
        public ICollection<School>? Schools { get; set; }
        public ICollection<Gladiator>? Gladiators { get; set; }
    }
}
