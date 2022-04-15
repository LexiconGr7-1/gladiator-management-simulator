using Gladiator.Core.Entities;

namespace Gladiator.Application.Gladiator.Responses
{
    public class GladiatorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int ArenaId { get; set; }
        public string ArenaName { get; set; }
    }
}
