using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Application.Gladiator.Responses
{
    public class GladiatorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Experience { get; set; }
        public int MaxGearSlots { get; set; }
        public int OccupiedGearSlots { get; set; }
        public int MaxGearWeight { get; set; }
        public int GearWeight { get; set; }
        public int Armour { get; set; }
        public int Damage { get; set; }
        public int Strength { get; set; }
        public int Speed { get; set; }
    }
}
