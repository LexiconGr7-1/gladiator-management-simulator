using Gladiator.Application.Gladiator.Responses;
using Gladiator.Application.Stats.Responses;

namespace Gladiator.Application.Gear.Responses
{
    public class GearResponseRelational : GearResponse
    {
        public StatsResponse StatModifiersPoints { get; set; }
        public StatsResponse StatModifiersPercent { get; set; }
        public GladiatorResponse Gladiator { get; set; }
    }
}
