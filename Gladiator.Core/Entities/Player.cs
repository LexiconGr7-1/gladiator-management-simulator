using Gladiator.Core.Entities.Base;

namespace Gladiator.Core.Entities
{
    public class Player : BaseEntityWithName
    {
        public ICollection<Arena> OwnedArenas { get; set; } = new List<Arena>();
        public ICollection<School> Schools { get; set; } = new List<School>();

        public List<Core.Entities.Gladiator> Gladiators =>
            Schools.SelectMany(s => s.Gladiators).ToList();
    }
}
