using AdventureWorks.Data.Entities;
using AdventureWorks.Data.Interfaces;

namespace AdventureWorks.Data.Repositories
{
    public class ProductRepository : Repository<ProductEntity>, IProductRepository
    {
        public ProductRepository(AdventureWorksContext context) : base(context)
        { }
    }
}