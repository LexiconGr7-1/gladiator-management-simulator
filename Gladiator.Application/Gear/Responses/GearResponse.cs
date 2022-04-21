using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Application.Gear.Responses
{
    public class GearResponse
    {
        public int Damage { get; set; }
        public int Armor { get; set; }
        public int Durability { get; set; }
        public int Slots { get; set; }
        public int Weight { get; set; }
        public int StatModifiersPointsId { get; set; }
        public int StatModifiersPercentId { get; set; }
        public int GladiatorId { get; set; }
    }
}
