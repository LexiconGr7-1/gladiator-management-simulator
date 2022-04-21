using Gladiator.Application.Gear.Responses;
using Gladiator.Application.Gladiator.Mappers;
using Gladiator.Application.Gladiator.Queries;
using Gladiator.Application.Gladiator.Responses;
using Gladiator.Core.Repositories;
using MediatR;

namespace Gladiator.Application.Gladiator.QueryHandlers
{
    public class GetGladiatorByIdHandler 
        : IRequestHandler<GetGladiatorByIdQuery, GladiatorFullResponse>
    {
        private readonly IGladiatorRepository _gladiatorRepository;

        public GetGladiatorByIdHandler(IGladiatorRepository gladiatorRepository)
        {
            _gladiatorRepository = gladiatorRepository;
        }

        public async Task<GladiatorFullResponse> Handle(
            GetGladiatorByIdQuery request,
            CancellationToken cancellationToken)
        {
            var gladiators = await _gladiatorRepository.GetByIdAsync(request.Id);

            if (gladiators == null)
                throw new ApplicationException("Could not get data");

            var response = GladiatorMapper.Mapper.Map<GladiatorFullResponse>(gladiators);

            if (response == null)
                throw new ApplicationException("Issue with mapper");

            return response;
        }
    }
}
