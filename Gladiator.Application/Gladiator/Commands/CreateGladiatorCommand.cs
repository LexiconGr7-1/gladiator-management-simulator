using Gladiator.Application.Gladiator.Responses;
using Gladiator.Core.Entities;
using MediatR;

namespace Gladiator.Application.Gladiator.Commands
{
    public class CreateGladiatorCommand : IRequest<GladiatorResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int SchoolId { get; set; }
    }
}
