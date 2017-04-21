using Employee.Data;
using Employee.DTO;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Employee.Domain.Services
{
    public class BaseService : IBaseService
    {
        private Lazy<ServiceManager> _ServiceManager = new Lazy<ServiceManager>(() => { return IOC.Register.ServiceProvider.GetService<ServiceManager>(); });
        private Lazy<RepositoryManager> _RepositoryManager = new Lazy<RepositoryManager>(() => { return IOC.Register.ServiceProvider.GetService<RepositoryManager>(); });
        private Lazy<ModelManager> _ModelManager = new Lazy<ModelManager>(() => { return IOC.Register.ServiceProvider.GetService<ModelManager>(); });


        public ServiceManager ServiceManager
        {
            get { return _ServiceManager.Value; }
        }

        public ModelManager ModelManager
        {
            get { return _ModelManager.Value; }
        }

        public RepositoryManager RepositoryManager
        {
            get { return _RepositoryManager.Value; }
        }
    }
}