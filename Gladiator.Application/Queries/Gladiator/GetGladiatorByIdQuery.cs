using MediatR;

namespace Gladiator.Application.Queries.Gladiator
{
    public class GetGladiatorByIdQuery
        : IRequest<IEnumerable<Core.Entities.Gladiator>>
    {
    }
}
