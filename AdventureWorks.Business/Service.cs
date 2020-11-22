using AdventureWorks.Business.Interfaces;
using AdventureWorks.Data.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorks.Business
{
    public class Service<TModel, TModelRequest, TEntity> : IService<TModel, TModelRequest, TEntity>
        where TModel : class
        where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public Service(IRepository<TEntity> _repository, IMapper _mapper)
        {
            this._repository = _repository;
            this._mapper = _mapper;
        }

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(entities);
        }

        public async Task<TModel> GetAsync(int id)
        {
            var entity = await _repository.GetAsync(id);

            return _mapper.Map<TModel>(entity);
        }

        public async Task CreateAsync(TModelRequest model)
        {
            var entity = _mapper.Map<TEntity>(model);

            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);

            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);

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