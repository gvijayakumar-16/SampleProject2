using Microsoft.Extensions.DependencyInjection;
using System;

namespace Employee.Domain.Services
{
    public class ServiceManager
    {
        public IBlogService BlogService
        {
            get { return IOC.Register.ServiceProvider.CreateScope().ServiceProvider.GetService<IBlogService>(); }
        }
    }
}
