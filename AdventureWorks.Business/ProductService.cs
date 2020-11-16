using AdventureWorks.Business.Interfaces;
using AdventureWorks.Business.Models.ProductScope;
using AdventureWorks.Data.Entities;
using AdventureWorks.Data.Interfaces;

namespace AdventureWorks.Business.Services
{
    public class ProductService : Service<ProductModel, ProductModelRequest, ProductEntity>, IProductService
    {
        public ProductService(IProductRepository _repository) : base(_repository)
        { }
    }
}