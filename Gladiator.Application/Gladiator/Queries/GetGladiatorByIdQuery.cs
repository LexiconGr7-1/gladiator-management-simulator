using MediatR;

namespace Gladiator.Application.Gladiator.Queries
{
    public class GetGladiatorByIdQuery
        : IRequest<IEnumerable<Core.Entities.Gladiator>>
    {
    }
}
