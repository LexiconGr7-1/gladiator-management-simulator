using Gladiator.Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gladiator.Core.Entities
{
    public class Player : BaseEntityWithName
    {
        public ICollection<Arena>? OwnedArenas { get; set; }
        public ICollection<School>? Schools { get; set; }

        // derived
        [NotMapped]
        public List<Core.Entities.Gladiator>? Gladiators =>
            Schools?.SelectMany(s => s.Gladiators ?? new List<Gladiator>()).ToList();
    }
}
