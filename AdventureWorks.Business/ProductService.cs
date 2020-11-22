using AdventureWorks.Business.Interfaces;
using AdventureWorks.Business.Models.ProductScope;
using AdventureWorks.Data.Entities;
using AdventureWorks.Data.Interfaces;
using AutoMapper;

namespace AdventureWorks.Business.Services
{
    public class ProductService : Service<ProductModel, ProductModelRequest, ProductEntity>, IProductService
    {
        public ProductService(IProductRepository _repository, IMapper _mapper) : base(_repository, _mapper)
        { }
    }
}