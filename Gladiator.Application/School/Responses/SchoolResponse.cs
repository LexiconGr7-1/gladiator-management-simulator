using Gladiator.Application.Gladiator.Responses;

namespace Gladiator.Application.School.Responses
{
    public class SchoolResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlayerId { get; set; }
        public int ArenaId { get; set; }
        public List<GladiatorResponse> Gladiators { get; set; }
    }
}
