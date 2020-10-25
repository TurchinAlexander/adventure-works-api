using AdventureWorks.Data.Entities;

namespace AdventureWorks.Data.Repositories
{
    public class ProductRepository : GenericRepository<ProductEntity>
    {
        public ProductRepository(AdventureWorksContext context) : base(context)
        { }
    }
}