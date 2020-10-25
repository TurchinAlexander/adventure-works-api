using AdventureWorks.Business.Models;
using AdventureWorks.Data.Entities;
using AdventureWorks.Data.Repositories;

namespace AdventureWorks.Business.Services
{
    public class ProductService : GenericService<ProductModel, ProductEntity>
    {
        public ProductService(GenericRepository<ProductModel> _repository) : base(_repository)
        { }
    }
}