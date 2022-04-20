using Gladiator.Application.Gear.Responses;
using Gladiator.Application.Gladiator.Responses;

namespace Gladiator.Application.Stats.Responses
{
    public class StatsResponseRelational : StatsResponse
    {
        public GearResponse Gear { get; set; }
        public GladiatorResponse Gladiator { get; set; }
    }
}
