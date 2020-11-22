using AdventureWorks.Data.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.Web.DependencyInjection.Modules
{
    public class DataEntitiesModule : IRegisterModule
    {
        public void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient(typeof(ProductEntity));
        }
    }
}