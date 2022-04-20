using Gladiator.Application.Arena.Responses;
using Gladiator.Application.Player.Responses;

namespace Gladiator.Application.School.Responses
{
    public class SchoolResponseRelational : SchoolResponse
    {
        public PlayerResponse Player { get; set; }
        public ArenaResponse Arena { get; set; }
    }
}
