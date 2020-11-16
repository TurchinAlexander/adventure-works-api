using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Interfaces
{
    public interface IService<TModel, TModelRequest, TEntity>
    {
        Task<IEnumerable<TModel>> GetAllAsync();

        Task<TModel> GetAsync(int id);

        Task CreateAsync(TModelRequest model);

        Task UpdateAsync(TModel model);

        Task DeleteAsync(TModel model);

        Task DeleteAsync(int id);
    }
}