using Gladiator.Application.Gladiator.Queries;
using Gladiator.Application.Gladiator.Responses;
using Gladiator.Core.Repositories;
using MediatR;

namespace Gladiator.Application.Gladiator.QueryHandlers
{
    public class GetAllGladiatorsHandler : IRequestHandler<
            GetAllGladiatorsQuery,
            List<Core.Entities.Gladiator>>
    {
        private readonly IGladiatorRepository _gladiatorRepository;

        public GetAllGladiatorsHandler(IGladiatorRepository gladiatorRepository)
        {
            _gladiatorRepository = gladiatorRepository;
        }

        public async Task<List<Core.Entities.Gladiator>> Handle(
            GetAllGladiatorsQuery request,
            CancellationToken cancellationToken)
        {
            return (List<Core.Entities.Gladiator>) await _gladiatorRepository.GetAllAsync();
        }
    }
}
