using Employee.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Employee.Data.IOC
{
    public static class Register
    {
        public static void RegisterRepositoryLayers(IServiceCollection services)
        {
            services.AddSingleton<RepositoryManager, RepositoryManager>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            DTOImplementation.IOC.Register.RegisterDTOImplementationLayers(services);
        }

        private static IServiceProvider _ServiceProvider;

        public static IServiceProvider ServiceProvider { get { return _ServiceProvider; } }

        public static void AssignServiceProvider(IServiceProvider srvProv)
        {
            _ServiceProvider = srvProv;
            DTOImplementation.IOC.Register.AssignServiceProvider(srvProv);
        }
    }
}