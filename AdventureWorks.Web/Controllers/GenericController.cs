using AdventureWorks.Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorks.Web.Controllers
{
    public class GenericController<TModel, TEntity> : ControllerBase
        where TEntity : class
        where TModel : class
    {
        private readonly GenericService<TModel, TEntity> _service;

        public GenericController(GenericService<TModel, TEntity> _service)
        {
            this._service = _service;
        }

        [HttpGet]
        public virtual async Task<IEnumerable<TModel>> GetAllAsync()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public virtual async Task<TModel> GetAsync(int id)
        {
            return await _service.GetAsync(id);
        }

        [HttpPost]
        public virtual async Task Create(TModel model)
        {
            await _service.CreateAsync(model);
        }

        [HttpPut]
        public virtual async Task Update(TModel model)
        {
            await _service.UpdateAsync(model);
        }

        [HttpDelete]
        public virtual async Task Delete(TModel model)
        {
            await _service.DeleteAsync(model);
        }

        [HttpDelete("{id}")]
        public virtual async Task Delete(int id)
        {
            await _service.DeleteAsync(id);
        }
    }
}