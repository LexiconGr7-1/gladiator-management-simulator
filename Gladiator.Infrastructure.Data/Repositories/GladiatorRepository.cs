using Gladiator.Core.Repositories;
using Gladiator.Infrastructure.Data.Data;
using Gladiator.Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Gladiator.Infrastructure.Data.Repositories
{
    public class GladiatorRepository
        : Repository<Core.Entities.Gladiator>, IGladiatorRepository
    {
        public GladiatorRepository(GladiatorContext gladiatorContext)
            : base(gladiatorContext) {}

        public new async Task<IList<Core.Entities.Gladiator>> GetAllAsync()
        {
            return await _context.Gladiator
                .Include(g => g.Stats)
                .Include(g => g.StatUpdates)
                .Include(g => g.Gear)
                .ThenInclude(g => g.StatModifiersPercent)
                .Include(g => g.Gear)
                .ThenInclude(g => g.StatModifiersPoints)
                .Include(g => g.School)
                .ThenInclude(s => s.Arena)
                .Include(g => g.Player)
                .ToListAsync();
        }
    }
}
