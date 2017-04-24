using Employee.Data;
using Employee.DTO;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Employee.Domain.Services
{
    public class BaseService : IBaseService
    {
        public ServiceManager ServiceManager
        {
            get { return IOC.Register.ServiceProvider.GetService<ServiceManager>(); }
        }

        public ModelManager ModelManager
        {
            get { return IOC.Register.ServiceProvider.GetService<ModelManager>(); }
        }

        public RepositoryManager RepositoryManager
        {
            get { return IOC.Register.ServiceProvider.GetService<RepositoryManager>(); }
        }
    }
}