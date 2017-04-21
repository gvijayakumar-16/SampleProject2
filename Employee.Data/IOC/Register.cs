using Employee.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Employee.Data.IOC
{
    public static class Register
    {
        private static IServiceProvider _serviceProvider;
        public static IServiceProvider ServiceProvider
        {
            get { return _serviceProvider; }
        }

        public static void RegisterRepositoryLayers(IServiceCollection services)
        {
            services.AddScoped<RepositoryManager, RepositoryManager>();

            services.AddScoped<BlogRepository, BlogRepository>();
        }

        public static void AssignServiceProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}