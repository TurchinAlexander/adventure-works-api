using AdventureWorks.Business.Models;
using AdventureWorks.Data.Entities;
using AdventureWorks.Data.Repositories;

namespace AdventureWorks.Business.Services
{
    public class ProductService : GenericService<ProductModel, ProductModelRequest, ProductEntity>
    {
        public ProductService(GenericRepository<ProductEntity> _repository) : base(_repository)
        { }
    }
}