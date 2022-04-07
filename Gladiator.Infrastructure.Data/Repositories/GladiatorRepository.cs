using Gladiator.Core.Repositories;
using Gladiator.Infrastructure.ApplicationData.Data;
using Gladiator.Infrastructure.ApplicationData.Repositories.Base;

namespace Gladiator.Infrastructure.ApplicationData.Repositories
{
    public class GladiatorRepository
        : Repository<Core.Entities.Gladiator>, IGladiatorRepository
    {
        public GladiatorRepository(GladiatorContext gladiatorContext)
            : base(gladiatorContext) {}
    }
}
