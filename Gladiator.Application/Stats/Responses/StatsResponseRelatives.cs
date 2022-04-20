using Gladiator.Application.Gear.Responses;
using Gladiator.Application.Gladiator.Responses;

namespace Gladiator.Application.Stats.Responses
{
    public class StatsResponseRelatives : StatsResponse
    {
        public GearResponse Gear { get; set; }
        public GladiatorResponse Gladiator { get; set; }
    }
}
