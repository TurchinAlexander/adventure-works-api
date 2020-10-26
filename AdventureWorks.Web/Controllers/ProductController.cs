using AdventureWorks.Business.Models;
using AdventureWorks.Business.Services;
using AdventureWorks.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorks.Web.Controllers
{
    [Route("[controller]")]
    public class ProductController : GenericController<ProductModel, ProductModelRequest, ProductEntity>
    {
        public ProductController(GenericService<ProductModel, ProductModelRequest, ProductEntity> _service) : base(_service)
        { }
    }
}