using Gladiator.Core.Entities;
using Gladiator.Core.Repositories.Base;

namespace Gladiator.Core.Repositories
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Task<IEnumerable<School>> GetAllSchoolsAsync();
        Task<Player> AddSchoolAsync(School school);
        Task<Player> RemoveSchoolAsync(School school);

        Task<IEnumerable<Entities.Gladiator>> GetAllGladiatorsInSchoolAsync(School school);
        Task<Player> RemoveGladiatorInSchoolAsync(School school, Entities.Gladiator gladiator);
        Task<Player> AddGladiatorInSchoolAsync(School school, Entities.Gladiator gladiator);

        Task<IEnumerable<Entities.Gladiator>> GetAllGladiatorsAsync();
        Task<Player> AddGladiatorAsync(Entities.Gladiator gladiator);
        Task<Player> RemoveGladiatorAsync(Entities.Gladiator gladiator);

    }
}
