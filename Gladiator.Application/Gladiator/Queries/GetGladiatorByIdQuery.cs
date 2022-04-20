using Gladiator.Application.Gear.Responses;
using MediatR;

namespace Gladiator.Application.Gladiator.Queries
{
    public class GetGladiatorByIdQuery
        : IRequest<IEnumerable<GearResponseRelational>>
    {
    }
}
