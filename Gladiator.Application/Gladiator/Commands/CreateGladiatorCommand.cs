using Gladiator.Application.Gladiator.Responses;
using MediatR;

namespace Gladiator.Application.Gladiator.Commands
{
    public class CreateGladiatorCommand : IRequest<GladiatorResponse>
    {
        public string Name { get; set; }
        public int PatternGladiatorId { get; set; }
        public int DifficultyLow { get; set; }
        public int DifficultyHigh { get; set; }
    }
}
