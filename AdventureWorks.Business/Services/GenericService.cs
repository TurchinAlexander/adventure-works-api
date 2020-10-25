using AdventureWorks.Data.Repositories;
using Mapster;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Services
{
    public class GenericService<TModel, TEntity>
        where TModel : class
        where TEntity : class
    {
        private readonly GenericRepository<TEntity> _repository;

        public GenericService(GenericRepository<TEntity> _repository)
        {
            this._repository = _repository;
        }

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();

            return entities.Adapt<IEnumerable<TModel>>();
        }

        public async Task<TModel> GetAsync(int id)
        {
            var entitiy = await _repository.GetAsync(id);

            return entitiy.Adapt<TModel>();
        }

        public async Task CreateAsync(TModel model)
        {
            var entity = model.Adapt<TEntity>();
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(TModel model)
        {
            var entity = model.Adapt<TEntity>();
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(TModel model)
        {
            var entity = model.Adapt<TEntity>();
            await _repository.DeleteAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetAsync(id);
            if (entity == null)
            {
                return;
            }

            await _repository.DeleteAsync(entity);
        }
    }
}