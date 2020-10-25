using AdventureWorks.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Data
{
    public class AdventureWorksContext : DbContext
    {
        public AdventureWorksContext(DbContextOptions options) : base(options)
        { }

        public DbSet<ProductEntity> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>(product =>
            {
                product.HasKey(p => p.ProductId);
                product.ToTable("Product", "Production");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}