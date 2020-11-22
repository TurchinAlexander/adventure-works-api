using AdventureWorks.Business;
using AdventureWorks.Business.Interfaces;
using AdventureWorks.Business.Services;
using AdventureWorks.Web.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.Web.DependencyConfiguration
{
    public class BusinessModule : IRegisterModule
    {
        public void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient(typeof(IService<,,>), typeof(Service<,,>));
            services.AddTransient(typeof(IProductService), typeof(ProductService));
        }
    }
}