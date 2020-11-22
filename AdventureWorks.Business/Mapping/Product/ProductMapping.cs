using AdventureWorks.Business.Models.ProductScope;
using AdventureWorks.Data.Entities;
using AutoMapper;

namespace AdventureWorks.Business.Mapping.Product
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<ProductModel, ProductEntity>();
            CreateMap<ProductModelRequest, ProductEntity>();

            CreateMap<ProductEntity, ProductModel>();
        }
    }
}