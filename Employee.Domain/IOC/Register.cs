using Employee.Domain.Services;
using Employee.DTO;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Employee.Domain.IOC
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
            RegisterDTOLayers(services);
            Data.IOC.Register.RegisterRepositoryLayers(services);
        }

        private static void RegisterServiceLayers(IServiceCollection services)
        {
            services.AddScoped<IBlogService, BlogService>();

            services.AddScoped<ServiceManager, ServiceManager>();
        }

        private static void RegisterDTOLayers(IServiceCollection services)
        {
            services.AddScoped<ModelManager, ModelManager>();
        }

        public static void AssignServiceProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            Data.IOC.Register.AssignServiceProvider(serviceProvider);
        }
    }
}