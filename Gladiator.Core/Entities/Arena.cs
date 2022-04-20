using Gladiator.Core.Entities.Base;

namespace Gladiator.Core.Entities
{
    public class Arena : BaseEntityWithName
    {
        public ICollection<Player> Owners { get; set; } = new List<Player>();
        public ICollection<School> Schools { get; set; } = new List<School>();

        public List<Core.Entities.Gladiator> Gladiators => 
            Schools.SelectMany(s => s.Gladiators).ToList();

        public List<Player> Players => 
            Schools
                .Select(s => s.Player)
                .Union(Owners)
                .ToList();
    }
}
