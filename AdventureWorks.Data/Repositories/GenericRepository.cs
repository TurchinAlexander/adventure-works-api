using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorks.Data.Repositories
{
    public class GenericRepository<TEntity>
        where TEntity : class
    {
        private readonly AdventureWorksContext context;

        public GenericRepository(AdventureWorksContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await context
                .Set<TEntity>()
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<TEntity> Get<T>(T id)
        {
            return await context
                .Set<TEntity>()
                .FindAsync(id)
                .ConfigureAwait(false);
        }

        public async Task Add(TEntity entity)
        {
            context
                .Entry(entity)
                .State = EntityState.Added;

            await context
                .SaveChangesAsync()
                .ConfigureAwait(false);
        }

        public async Task Update(TEntity entity)
        {
            context.Set<TEntity>()
                .Update(entity);

            await context.SaveChangesAsync()
                .ConfigureAwait(false);
        }

        public async Task Delete(TEntity entity)
        {
            context
                .Set<TEntity>()
                .Remove(entity);

            await context.SaveChangesAsync()
                .ConfigureAwait(false);
        }
    }
}