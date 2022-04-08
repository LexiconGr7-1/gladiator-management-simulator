using Gladiator.Core.Repositories;
using Gladiator.Infrastructure.Data.Data;
using Gladiator.Infrastructure.Data.Repositories.Base;

namespace Gladiator.Infrastructure.Data.Repositories
{
    public class GladiatorRepository
        : Repository<Core.Entities.Gladiator>, IGladiatorRepository
    {
        public GladiatorRepository(GladiatorContext gladiatorContext)
            : base(gladiatorContext) {}
    }
}
