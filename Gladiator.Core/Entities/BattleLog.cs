using Gladiator.Core.Entities.Base;

namespace Gladiator.Core.Entities
{
    public class BattleLog : BaseEntity
    {
        public string Log { get; set; } = "";

        public int GladiatorId { get; set; }
        public Core.Entities.Gladiator? Gladiator { get; set; }
    }
}
