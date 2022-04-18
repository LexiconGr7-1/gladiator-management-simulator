using MediatR;

namespace Gladiator.Application.Gladiator.Queries
{
    public class GetAllGladiatorsQuery
        : IRequest<IEnumerable<Core.Aggregates.GladiatorAggregate.Gladiator>>
    {
    }
}
