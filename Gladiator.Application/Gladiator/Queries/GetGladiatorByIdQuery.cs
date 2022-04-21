using Gladiator.Application.Gear.Responses;
using Gladiator.Application.Gladiator.Responses;
using MediatR;

namespace Gladiator.Application.Gladiator.Queries
{
    public class GetGladiatorByIdQuery
        : IRequest<GladiatorFullResponse>
    {
        public readonly int Id;

        public GetGladiatorByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
