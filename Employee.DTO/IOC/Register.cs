using Microsoft.Extensions.DependencyInjection;
using System;

namespace Employee.DTO.IOC
{
    public static class Register
    {
        private static IServiceProvider _ServiceProvider;
        public static IServiceProvider ServiceProvider { get { return _ServiceProvider; } }
        
        public static void RegisterDTOLayers(IServiceCollection services)
        {
            //Register the manager
            services.AddSingleton<ModelManager, ModelManager>();
        }

        public static void AssignServiceProvider(IServiceProvider srvProv)
        {
            _ServiceProvider = srvProv;
        }
    }
}