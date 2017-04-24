using Employee.DTO;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Employee.DTOImplementation.IOC
{
    public static class Register
    {
        private static IServiceProvider _ServiceProvider;
        public static IServiceProvider ServiceProvider { get { return _ServiceProvider; } }
        
        public static void RegisterDTOImplementationLayers(IServiceCollection services)
        {
            //Register the services
            services.AddScoped<IBlogDTO, BlogDTO>();
            services.AddScoped<IPostDTO, PostDTO>();
        }

        public static void AssignServiceProvider(IServiceProvider srvProv)
        {
            _ServiceProvider = srvProv;
        }
    }
}
