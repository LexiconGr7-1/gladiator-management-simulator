using Gladiator.Core.Entities;
using Gladiator.Core.Repositories.Base;

namespace Gladiator.Core.Repositories
{
    public interface IArenaRepository : IRepository<Arena>
    {
        Task<IEnumerable<School>> GetAllSchoolsAsync();
        Task<IEnumerable<Entities.Gladiator>> GetAllGladiatorsAsync();
    }
}
