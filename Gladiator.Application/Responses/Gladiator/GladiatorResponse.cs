using Gladiator.Core.Entities;

namespace Gladiator.Application.Responses.Gladiator
{
    public class GladiatorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public School School { get; set; }
        public Player Player { get; set; }
    }
}
