using Gladiator.Application.Responses;
using Gladiator.Core.Entities;
using MediatR;

namespace Gladiator.Application.Commands
{
    public class CreateGladiatorCommand : IRequest<GladiatorResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public IEnumerable<School> Schools { get; set; }
    }
}
