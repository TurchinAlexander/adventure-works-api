using AdventureWorks.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorks.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly AdventureWorksContext _context;

        public Repository(AdventureWorksContext _context)
        {
            this._context = _context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context
                .Set<TEntity>()
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _context
                .Set<TEntity>()
                .FindAsync(id)
                .ConfigureAwait(false);
        }

        public async Task AddAsync(TEntity entity)
        {
            _context
                .Entry(entity)
                .State = EntityState.Added;

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>()
                .Update(entity);

            await _context.SaveChangesAsync()
                .ConfigureAwait(false);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context
                .Set<TEntity>()
                .Remove(entity);

            await _context.SaveChangesAsync()
                .ConfigureAwait(false);
        }
    }
}