using System;
using System.Reflection;

namespace AdventureWorks.Web.DependencyInjection
{
    public interface IRegisterContainer
    {
        public IRegisterContainer RegisterModule(Type module);

        public IRegisterContainer RegisterModule<TModule>()
         where TModule : IRegisterModule;

        public IRegisterContainer RegisterAssemblies(params Assembly[] assemblies);
    }
}