using Gladiator.Application.Arena.Responses;
using Gladiator.Application.Gear.Responses;
using Gladiator.Application.Player.Responses;
using Gladiator.Application.School.Responses;
using Gladiator.Application.Stats.Responses;

namespace Gladiator.Application.Gladiator.Responses
{
    public class GladiatorResponseRelatives : GladiatorResponse
    {
        public StatsResponse Stats { get; set; }
        public StatsResponse StatUpdates { get; set; }
        public ArenaResponse Arena { get; set; }
        public SchoolResponse School { get; set; }
        public PlayerResponse Player { get; set; }
        public List<GearResponse> Gear { get; set; }
    }
}
