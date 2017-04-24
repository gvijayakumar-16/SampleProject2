using Employee.DTO;
using System.Collections.Generic;

namespace Employee.Domain.Services
{
    public interface IBlogService
    {
        void Save(IBlogDTO model);
        IEnumerable<IBlogDTO> GetAllBlogs();
        void Delete(int blogId);
    }
}