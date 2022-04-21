using Gladiator.Application.Gladiator.Responses;
using MediatR;

namespace Gladiator.Application.Gladiator.Queries
{
    public class GetAllGladiatorsQuery
        : IRequest<IList<GladiatorFullResponse>>
    {
    }
}
