using Employee.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Employee.Data
{
    public class RepositoryManager
    {
        private IServiceProvider _ServiceProvider;
        public RepositoryManager(IServiceProvider srvProv)
        {
            _ServiceProvider = srvProv;
        }

        public BlogRepository BlogRepository
        {
            get { return _ServiceProvider.GetService<BlogRepository>(); }
        }
    }
}
