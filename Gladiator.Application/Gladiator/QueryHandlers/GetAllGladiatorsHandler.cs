using Gladiator.Application.Gladiator.Mappers;
using Gladiator.Application.Gladiator.Queries;
using Gladiator.Application.Gladiator.Responses;
using Gladiator.Core.Repositories;
using MediatR;

namespace Gladiator.Application.Gladiator.QueryHandlers
{
    public class GetAllGladiatorsHandler : IRequestHandler<
            GetAllGladiatorsQuery,
            IList<GladiatorFullResponse>>
    {
        private readonly IGladiatorRepository _gladiatorRepository;

        public GetAllGladiatorsHandler(IGladiatorRepository gladiatorRepository)
        {
            _gladiatorRepository = gladiatorRepository;
        }

        public async Task<IList<GladiatorFullResponse>> Handle(
            GetAllGladiatorsQuery request,
            CancellationToken cancellationToken)
        {
            var gladiators = await _gladiatorRepository.GetAllAsync();

            if (gladiators == null)
                throw new ApplicationException("Could not get data");

            var response = GladiatorMapper.Mapper.Map<IList<GladiatorFullResponse>>(gladiators);

            if (response == null)
                throw new ApplicationException("Issue with mapper");

            return response;

        }
    }
}
