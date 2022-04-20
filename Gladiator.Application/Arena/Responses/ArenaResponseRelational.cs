using Gladiator.Application.Gladiator.Responses;
using Gladiator.Application.Player.Responses;
using Gladiator.Application.School.Responses;

namespace Gladiator.Application.Arena.Responses
{
    public class ArenaResponseRelational : ArenaResponse
    {
        public List<PlayerResponse> Owners { get; set; }
        public List<SchoolResponse> Schools { get; set; }

        // derived from schools
        public List<PlayerResponse> Players { get; set; }

        // derived from schools
        public List<GladiatorResponse> Gladiators { get; set; }
    }
}
