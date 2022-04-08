using Gladiator.Application.Responses.Gladiator;
using Gladiator.Core.Entities;
using MediatR;

namespace Gladiator.Application.Commands.Gladiator
{
    public class CreateGladiatorCommand : IRequest<GladiatorResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public School Schools { get; set; }
    }
}
