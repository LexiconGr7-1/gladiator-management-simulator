using Gladiator.Core.Aggregates.ArenaAggregate;
using Gladiator.Core.Aggregates.BaseAggregate;
using Gladiator.Core.Aggregates.PlayerAggregate;
using Gladiator.Core.Aggregates.SchoolAggregate;

namespace Gladiator.Core.Aggregates.GladiatorAggregate
{
    public class Gladiator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
    }
}
