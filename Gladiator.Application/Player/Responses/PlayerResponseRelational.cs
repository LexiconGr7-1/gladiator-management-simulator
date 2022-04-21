using Gladiator.Application.Arena.Responses;
using Gladiator.Application.Gladiator.Responses;
using Gladiator.Application.School.Responses;

namespace Gladiator.Application.Player.Responses
{
    public class PlayerResponseRelational : PlayerResponse
    {
        public List<ArenaResponse> Arenas { get; set; }
        public List<SchoolResponse> Schools { get; set; }
        public List<GladiatorResponse> Gladiators { get; set; }
    }
}
