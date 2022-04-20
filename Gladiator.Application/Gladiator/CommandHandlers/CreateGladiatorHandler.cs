using Gladiator.Application.Gladiator.Commands;
using Gladiator.Application.Gladiator.Responses;
using Gladiator.Application.Gladiator.Mappers;
using Gladiator.Core.Repositories;
using MediatR;

namespace Gladiator.Application.Gladiator.CommandHandlers
{
    public class CreateGladiatorHandler
        : IRequestHandler<CreateGladiatorCommand, GladiatorResponseRelational>
    {
        private readonly IGladiatorRepository _gladiatorRepository;

        public CreateGladiatorHandler(IGladiatorRepository gladiatorRepository)
        {
            _gladiatorRepository = gladiatorRepository;
        }

        public async Task<GladiatorResponseRelational> Handle(
            CreateGladiatorCommand request,
            CancellationToken cancellationToken)
        {
            var gladiatorEntity = GladiatorMapper.Mapper.Map<Core.Entities.Gladiator>(request);

            if (gladiatorEntity == null)
                throw new ApplicationException("Issue with mapper");

            var newGladiator = await _gladiatorRepository.AddAsync(gladiatorEntity);
            var gladiatorResponse = GladiatorMapper.Mapper.Map<GladiatorResponseRelational>(newGladiator);

            return gladiatorResponse;
        }
    }
}
