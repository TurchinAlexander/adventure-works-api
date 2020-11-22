using System.Configuration;
using AdventureWorks.Data;
using AdventureWorks.Data.Interfaces;
using AdventureWorks.Data.Repositories;
using AdventureWorks.Web.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.Web.DependencyConfiguration
{
    public class DataConfig : IRegisterModule
    {
        public void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IProductRepository), typeof(ProductRepository));

            services.AddDbContext<AdventureWorksContext>(options =>
            {
                options.UseSqlServer(GetConnectionString());
            });
        }

        private string GetConnectionString()
        {
            const string DefaultConnectionStringName = "Default";

            return ConfigurationManager
                .ConnectionStrings[DefaultConnectionStringName]
                .ConnectionString;
        }
    }
}