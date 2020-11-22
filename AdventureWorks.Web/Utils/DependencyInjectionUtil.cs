using System.Linq;
using System.Reflection;
using AdventureWorks.Web.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.Web.Utils
{
    public static class DependencyInjectionUtil
    {
        public static void AddDependecyRegistration(this IServiceCollection services)
        {
            new DefaultRegisterContainer(services)
                .RegisterAssemblies(Assembly.GetExecutingAssembly());
        }
    }
}