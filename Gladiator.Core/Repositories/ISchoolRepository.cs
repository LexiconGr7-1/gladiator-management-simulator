using Gladiator.Core.Entities;
using Gladiator.Core.Repositories.Base;

namespace Gladiator.Core.Repositories
{
    public interface ISchoolRepository : IRepository<School>
    {
        Task<IEnumerable<Entities.Gladiator>> GetAllGladiatorsAsync();
        Task<School> RemoveGladiatorAsync(Entities.Gladiator gladiator);
        Task<School> AddGladiatorAsync(Entities.Gladiator gladiator);
    }
}
