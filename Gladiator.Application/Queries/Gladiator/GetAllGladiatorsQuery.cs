using MediatR;

namespace Gladiator.Application.Queries.Gladiator
{
    public class GetAllGladiatorsQuery
        : IRequest<IEnumerable<Core.Entities.Gladiator>>
    {
    }
}
