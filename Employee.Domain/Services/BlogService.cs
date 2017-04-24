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
        public void Save(IBlogDTO model)
        {
            RepositoryManager.BlogRepository.Save(model);
        }

        /// <summary>
        /// Get all the blogs
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IBlogDTO> GetAllBlogs()
        {
            return RepositoryManager.BlogRepository.GetAllBlogs();
        }

        /// <summary>
        /// Delete a blog
        /// </summary>
        /// <param name="blogId"></param>
        public void Delete(int blogId)
        {
            RepositoryManager.BlogRepository.DeleteBlog(blogId);
        }
    }
}
