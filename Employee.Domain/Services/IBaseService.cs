using Employee.Data;
using Employee.DTO;

namespace Employee.Domain.Services
{
    public interface IBaseService
    {
        ModelManager ModelManager { get; }
        RepositoryManager RepositoryManager { get; }
        ServiceManager ServiceManager { get; }
    }
}