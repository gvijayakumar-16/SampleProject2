using Employee.DTO;
using System.Collections.Generic;

namespace Employee.Data.Repository
{
    public interface IBlogRepository
    {
        void Save(IBlogDTO model);
        IEnumerable<IBlogDTO> GetAllBlogs();
        void DeleteBlog(int blogID);
    }
}