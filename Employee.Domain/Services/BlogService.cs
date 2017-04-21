using Employee.Data;
using Employee.DTO;
using System;
using System.Collections.Generic;

namespace Employee.Domain.Services
{
    public class BlogService : BaseService, IBlogService
    {
        /// <summary>
        /// Save the blog to DB
        /// </summary>
        /// <param name="model"></param>
        public void Save(BlogDTO model)
        {
            RepositoryManager.BlogRepository.Save(model);
        }

        /// <summary>
        /// Get all the blogs
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BlogDTO> GetAllBlogs()
        {
            return RepositoryManager.BlogRepository.GetAllBlogs();
        }
    }
}
