using Gladiator.Application.Commands.Gladiator;
using Gladiator.Application.Mappers.Gladiator;
using Gladiator.Application.Responses.Gladiator;
using Gladiator.Core.Repositories;
using MediatR;

namespace Gladiator.Application.Handlers.CommandHandlers.Gladiator
{
    public class CreateGladiatorHandler
        : IRequestHandler<CreateGladiatorCommand, GladiatorResponse>
    {
        private readonly IGladiatorRepository _gladiatorRepository;

        public CreateGladiatorHandler(IGladiatorRepository gladiatorRepository)
        {
            _gladiatorRepository = gladiatorRepository;
        }

        public async Task<GladiatorResponse> Handle(
            CreateGladiatorCommand request,
            CancellationToken cancellationToken)
        {
            var gladiatorEntity = GladiatorMapper.Mapper.Map<Core.Entities.Gladiator>(request);

            if (gladiatorEntity is null)
                throw new ApplicationException("Issue with mapper");

            var newGladiator = await _gladiatorRepository.AddAsync(gladiatorEntity);
            var gladiatorResponse = GladiatorMapper.Mapper.Map<GladiatorResponse>(newGladiator);

            return gladiatorResponse;
        }
    }
}
