using Employee.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Employee.Data
{
    public class RepositoryManager
    {
        public IBlogRepository BlogRepository
        {
            get { return IOC.Register.ServiceProvider.CreateScope().ServiceProvider.GetService<IBlogRepository>(); }
        }
    }
}
