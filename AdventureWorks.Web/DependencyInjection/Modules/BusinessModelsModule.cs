using AdventureWorks.Business.Models.ProductScope;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.Web.DependencyInjection.Modules
{
    public class BusinessModelsModule : IRegisterModule
    {
        public void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient(typeof(ProductModel));
            services.AddTransient(typeof(ProductModelRequest));
        }
    }
}