using Employee.DTO;
using System.Collections.Generic;

namespace Employee.Domain.Services
{
    public interface IBlogService
    {
        void Save(BlogDTO model);
        IEnumerable<BlogDTO> GetAllBlogs();
    }
}