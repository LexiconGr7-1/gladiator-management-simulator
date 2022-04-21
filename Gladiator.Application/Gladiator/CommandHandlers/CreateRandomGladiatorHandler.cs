using Gladiator.Application.Gladiator.Commands;
using Gladiator.Application.Gladiator.Mappers;
using Gladiator.Application.Gladiator.Responses;
using Gladiator.Core.Repositories;
using MediatR;

namespace Gladiator.Application.Gladiator.CommandHandlers
{
    public class CreateRandomGladiatorHandler
        : IRequestHandler<CreateRandomGladiatorCommand, GladiatorFullResponse>
    {
        private readonly Random random = new Random();
        private readonly IGladiatorRepository _gladiatorRepository;

        public CreateRandomGladiatorHandler(IGladiatorRepository gladiatorRepository)
        {
            _gladiatorRepository = gladiatorRepository;
        }

        public async Task<GladiatorFullResponse> Handle(
            CreateRandomGladiatorCommand command,
            CancellationToken cancellationToken)
        {
            // get gladiator to use as pattern
            var patternGladiator = await _gladiatorRepository.GetByIdAsync(command.Id);
            if (patternGladiator == null)
                throw new ApplicationException("Could not get data");

            // create a new blank gladiator
            var newGladiator = await _gladiatorRepository.AddAsync(new Core.Entities.Gladiator());
            if (newGladiator == null)
                throw new ApplicationException("Could not set data");



            var generatedGladiator = await RandomizeGladiator(command);

            if (generatedGladiator == null)
                throw new ApplicationException("Could not generate gladiator");

            newGladiator = await _gladiatorRepository.UpdateAsync(generatedGladiator);

            var gladiatorResponse = GladiatorMapper.Mapper.Map<GladiatorFullResponse>(newGladiator);

            return gladiatorResponse;
        }

        public async Task<Core.Entities.Gladiator> GenerateRandomGladiator(
            Core.Entities.Gladiator newGladiator,
            Core.Entities.Gladiator patternGladiator,
            CreateRandomGladiatorCommand options)
        {
            newGladiator.Name = "Gladiator " + newGladiator.Id;
            newGladiator.Health = RandomizedStat(patternGladiator.Health, options);
            newGladiator.StatUpdates = new Core.Entities.Stats();
            newGladiator.CreatedAt = DateTime.UtcNow;

            newGladiator.Stats = new Core.Entities.Stats
            {
                Agility = RandomizedStat(patternGladiator?.Stats?.Agility ?? -1, options),
                Constitution = RandomizedStat(patternGladiator?.Stats?.Constitution ?? -1, options),
                Dexterity = RandomizedStat(patternGladiator?.Stats?.Dexterity ?? -1, options),
                Intelligence = RandomizedStat(patternGladiator?.Stats?.Intelligence ?? -1, options),
                Strength = RandomizedStat(patternGladiator?.Stats?.Strength ?? -1, options)
            };

            newGladiator.Gear = new List<Core.Entities.Gear>
            {
                new Core.Entities.Gear
                {
                    Name = "Gear " + random.Next().ToString(),
                    Armor = 0,
                    
                }
            };

            return newGladiator;
        }

        private int RandomizedStat(int stat,
            CreateRandomGladiatorCommand options)
        {
            int lower;
            int upper;

            if (stat < 0)
            {
                lower = options.LowerSpreadPoints;
                upper = options.UpperSpreadPoints;
            }
            else
            {
                lower = (int)(
                    stat
                    - stat * options.LowerSpreadPoints
                    - options.UpperSpreadPoints);

                upper = (int)(
                    stat
                    + stat * options.LowerSpreadPercent
                    + options.UpperSpreadPercent);
            }

            if (lower < 0)
                lower = 0;

            if (upper < 0)
                upper = 0;

            return random.Next(lower, upper);
        }
    }
}
