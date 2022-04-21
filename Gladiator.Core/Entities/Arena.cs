using System.ComponentModel.DataAnnotations.Schema;
using Gladiator.Core.Entities.Base;

namespace Gladiator.Core.Entities
{
    public class Arena : BaseEntityWithName
    {
        public ICollection<Player> Owners { get; set; } = new List<Player>();
        public ICollection<School>? Schools { get; set; }

        // derived
        [NotMapped]
        public List<Core.Entities.Gladiator>? Gladiators => 
            Schools?.SelectMany(s => s.Gladiators ?? new List<Core.Entities.Gladiator>())?.ToList();

        [NotMapped]
        public List<Player>? Players => 
            Schools?.Select(s => s.Player).Union(Owners).ToList();
    }
}
