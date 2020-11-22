using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.Web.DependencyInjection
{
    public interface IRegisterModule
    {
        public void RegisterDependencies(IServiceCollection services);
    }
}