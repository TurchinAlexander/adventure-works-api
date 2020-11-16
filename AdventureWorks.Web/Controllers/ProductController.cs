using AdventureWorks.Business.Interfaces;
using AdventureWorks.Business.Models.ProductScope;
using AdventureWorks.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorks.Web.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller<ProductModel, ProductModelRequest, ProductEntity>
    {
        public ProductController(IProductService _service) : base(_service)
        { }
    }
}