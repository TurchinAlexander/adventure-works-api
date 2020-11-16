using AdventureWorks.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorks.Web.Controllers
{
    [Produces("application/json")]
    public class Controller<TModel, TModelRequest, TEntity> : ControllerBase
        where TEntity : class
        where TModel : class
    {
        private readonly IService<TModel, TModelRequest, TEntity> _service;

        public Controller(IService<TModel, TModelRequest, TEntity> _service)
        {
            this._service = _service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<IEnumerable<TModel>> GetAllAsync()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<TModel> GetAsync([FromRoute] int id)
        {
            return await _service.GetAsync(id);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public virtual async Task Create([FromBody] TModelRequest model)
        {
            await _service.CreateAsync(model);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task Update([FromBody] TModel model)
        {
            await _service.UpdateAsync(model);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task Delete([FromBody] TModel model)
        {
            await _service.DeleteAsync(model);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task Delete([FromRoute] int id)
        {
            await _service.DeleteAsync(id);
        }
    }
}