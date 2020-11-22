using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.Web.DependencyInjection
{
    public class DefaultRegisterContainer : IRegisterContainer
    {
        private readonly IServiceCollection serviceCollection;
        private readonly IConfiguration configuration;

        public DefaultRegisterContainer(IServiceCollection serviceCollection)
        {
            this.serviceCollection = serviceCollection;
            this.configuration = configuration;
        }

        public IRegisterContainer RegisterModule<TModule>()
            where TModule : IRegisterModule
        {
            RegisterModule(typeof(TModule));

            return this;
        }

        public IRegisterContainer RegisterAssemblies(params Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var moduleTypes = assembly
                    .GetTypes()
                    .Where(t => typeof(IRegisterModule).IsAssignableFrom(t));

                foreach (var moduleType in moduleTypes)
                {
                    RegisterModule(moduleType);
                }
            }
            return this;
        }

        public IRegisterContainer RegisterModule(Type moduleType)
        {
            var types = new[]
            {
                serviceCollection.GetType(),
                configuration.GetType()
            };

            var arguments = new object[]
            {
                serviceCollection,
                configuration
            };

            this.RegisterModule(moduleType, types, arguments);

            return this;
        }

        private void RegisterModule(Type moduleType, Type[] argumentTypes, object[] argumentValues)
        {
            var module = moduleType.GetType()
                .GetConstructor(argumentTypes)?
                .Invoke(argumentValues) as IRegisterModule;

            module.RegisterDependencies(this.serviceCollection);
        }
    }
}