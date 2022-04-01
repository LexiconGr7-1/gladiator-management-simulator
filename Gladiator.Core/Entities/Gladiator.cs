using Gladiator.Core.Entities.Base;

namespace Gladiator.Core.Entities
{
    public class Gladiator : BaseEntityWithName
    {
        // stats
        public int Health { get; set; }
        public int Strength { get; set; }

        public School School { get; set; }
    }
}
