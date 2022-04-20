using Gladiator.Application.Gladiator.Responses;
using Gladiator.Core.Repositories;
using MediatR;

namespace Gladiator.Application.Gladiator.Queries
{
    public class GetAllGladiatorsQuery
        : IRequest<IList<GladiatorResponseRelational>>
    {
    }
}
