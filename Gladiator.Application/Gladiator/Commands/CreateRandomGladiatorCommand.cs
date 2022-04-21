using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gladiator.Application.Gladiator.Responses;
using MediatR;

namespace Gladiator.Application.Gladiator.Commands
{
    public class CreateRandomGladiatorCommand : IRequest<GladiatorFullResponse>
    {
        public readonly int Id;

        public CreateRandomGladiatorCommand(int id)
        {
            Id = id;
        }

        public int DifficultyPoints { get; set; }
        public double DifficultyPercent { get; set; }
        public double UpperSpreadPercent { get; set; }
        public double LowerSpreadPercent { get; set; }
        public int UpperSpreadPoints { get; set; }
        public int LowerSpreadPoints { get; set; }
    }
}
