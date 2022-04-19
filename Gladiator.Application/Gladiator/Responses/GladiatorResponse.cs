using Gladiator.Core.Entities;
using System.Text.Json.Serialization;

namespace Gladiator.Application.Gladiator.Responses
{
    public class GladiatorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Health { get; set; }
        public int Experience { get; set; }
        public int TotalExperience { get; set; }

        public int MaxGearSlots { get; set; }
        public int MaxGearWeight { get; set; }

        public Stats Stats { get; set; }
        public Stats StatUpdatesCount { get; set; }

        public int Armour { get; set; }
        public int Damage { get; set; }

        public Arena Arena { get; set; }
        public School School { get; set; }
        public Player Player { get; set; }

        public List<Gear> Gear { get; set; }
    }
}
