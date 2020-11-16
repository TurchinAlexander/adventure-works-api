using AdventureWorks.Business.Models.ProductScope;
using AdventureWorks.Data.Entities;

namespace AdventureWorks.Business.Interfaces
{
    public interface IProductService : IService<ProductModel, ProductModelRequest, ProductEntity>
    {
    }
}