using Microsoft.Extensions.DependencyInjection;
using System;

namespace Employee.Domain.Services
{
    public class ServiceManager : IDisposable
    {
        private IServiceProvider _ServiceProvider;
        public ServiceManager(IServiceProvider srvProv)
        {
            _ServiceProvider = srvProv;
        }

        public IBlogService BlogService
        {
            get { return _ServiceProvider.GetService<IBlogService>(); }
        }

        public void Dispose()
        {
            GC.Collect();
        }
    }
}
