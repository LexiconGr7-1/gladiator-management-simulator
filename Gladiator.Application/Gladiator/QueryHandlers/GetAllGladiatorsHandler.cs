using Gladiator.Application.Gladiator.Queries;
using Gladiator.Core.Repositories;
using MediatR;

namespace Gladiator.Application.Gladiator.QueryHandlers
{
    public class GetAllGladiatorsHandler
        : IRequestHandler<GetAllGladiatorsQuery,
            IEnumerable<Core.Entities.Gladiator>>
    {
        private readonly IGladiatorRepository _gladiatorRepository;

        public GetAllGladiatorsHandler(IGladiatorRepository gladiatorRepository)
        {
            _gladiatorRepository = gladiatorRepository;
        }

        public async Task<IEnumerable<Core.Entities.Gladiator>> Handle(
            GetAllGladiatorsQuery request,
            CancellationToken cancellationToken)
        {
            return await _gladiatorRepository.GetAllAsync();
        }
    }
}
