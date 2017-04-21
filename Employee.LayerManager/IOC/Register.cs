using Microsoft.Extensions.DependencyInjection;
using System;

namespace Employee.LayerManager.IOC
{
    public static class Register
    {
        private static IServiceProvider _serviceProvider;

        public static IServiceProvider ServiceProvider
        {
            get { return _serviceProvider; }
        }

        public static void RegisterAllLayers(IServiceCollection services)
        {
            RegisterServiceLayers(services);
            Data.IOC.Register.RegisterRepositoryLayers(services);
        }

        private static void RegisterServiceLayers(IServiceCollection services)
        {
            services.AddSingleton<ServiceManager, ServiceManager>();
        }

        public static void AssignServiceProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            Domain.IOC.Register.AssignServiceProvider(serviceProvider);
            Data.IOC.Register.AssignServiceProvider(serviceProvider);
        }
    }
}
