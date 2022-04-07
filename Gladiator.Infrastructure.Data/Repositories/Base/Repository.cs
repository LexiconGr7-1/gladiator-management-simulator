using Gladiator.Core.Repositories.Base;
using Gladiator.Infrastructure.ApplicationData.Data;
using Microsoft.EntityFrameworkCore;

namespace Gladiator.Infrastructure.ApplicationData.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly GladiatorContext _context;

        public Repository(GladiatorContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
