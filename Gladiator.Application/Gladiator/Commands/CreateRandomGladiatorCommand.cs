using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Application.Gladiator.Commands
{
    public class CreateRandomGladiatorCommand
    {
        public string Name { get; set; }
        public int DifficultyLow { get; set; }
        public int DifficultyHigh { get; set; }
    }
}
