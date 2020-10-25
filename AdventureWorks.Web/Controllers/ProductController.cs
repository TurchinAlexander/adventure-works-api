using AdventureWorks.Business.Models;
using AdventureWorks.Business.Services;
using AdventureWorks.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorks.Web.Controllers
{
    [Route("[controller]")]
    public class ProductController : GenericController<ProductModel, ProductEntity>
    {
        public ProductController(GenericService<ProductModel, ProductEntity> _service) : base(_service)
        { }
    }
}