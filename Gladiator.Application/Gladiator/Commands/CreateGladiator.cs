
using MediatR;

namespace Gladiator.Application.Gladiator.Commands
{
    public class CreateGladiator : IRequest<OperationResult<<Gladiator>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int SchoolId { get; set; }
    }
}
