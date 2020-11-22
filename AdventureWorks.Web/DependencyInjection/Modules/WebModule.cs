using AdventureWorks.Web.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.Web.DependencyConfiguration
{
    public class WebModule : IRegisterModule
    {
        public void RegisterDependencies(IServiceCollection services)
        {
        }
    }
}