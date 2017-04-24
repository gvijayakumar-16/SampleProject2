using Employee.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Employee.Domain.IOC
{
    public static class Register
    {
        private static IServiceProvider _ServiceProvider;
        public static IServiceProvider ServiceProvider { get { return _ServiceProvider; } }

        public static void RegisterAllLayers(IServiceCollection services)
        {
            RegisterServiceLayers(services);
            DTO.IOC.Register.RegisterDTOLayers(services);
            Data.IOC.Register.RegisterRepositoryLayers(services);
        }

        private static void RegisterServiceLayers(IServiceCollection services)
        {
            //Register the services
            services.AddScoped<IBlogService, BlogService>();

            //Register the manager
            services.AddSingleton<ServiceManager, ServiceManager>();
        }

        public static void AssignServiceProvider(IServiceProvider srvProv)
        {
            _ServiceProvider = srvProv;
            DTO.IOC.Register.AssignServiceProvider(srvProv);
            Data.IOC.Register.AssignServiceProvider(srvProv);
        }
    }
}