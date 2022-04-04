using Gladiator.Application.Commands;
using Gladiator.Application.Mappers;
using Gladiator.Application.Responses;
using Gladiator.Core.Repositories;
using MediatR;

namespace Gladiator.Application.Handlers.CommandHandlers
{
    internal class CreateGladiatorHandler
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
            if (gladiatorEntity == null)
                throw new ApplicationException("Issue with mapper");
            var newGladiator = await _gladiatorRepository.AddAsync(gladiatorEntity);
            var gladiatorResponse = GladiatorMapper.Mapper.Map<GladiatorResponse>(newGladiator);
            return gladiatorResponse;
        }
    }
}
