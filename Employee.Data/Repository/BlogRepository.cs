using Employee.Data.Models;
using Employee.DTO;
using System.Collections.Generic;

namespace Employee.Data.Repository
{
    public class BlogRepository : Repository<Blog>
    {
        public BlogRepository(BloggingContext context)
            : base(context)
        { }

        /// <summary>
        /// Update/Insert the blogs to DB
        /// </summary>
        /// <param name="model"></param>
        public void Save(BlogDTO model)
        {
            var dataModel = new Blog();
            AutoMapper.Mapper.Map(model, dataModel);
            dataModel.Validate();
            if (dataModel.BlogId > 0)
            {
                Update(dataModel);
                return;
            }
            Insert(dataModel);
        }

        /// <summary>
        /// Get all the blogs from DB
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BlogDTO> GetAllBlogs()
        {
            var blogs = GetAll();
            var blogsDTO = new List<BlogDTO>();
            AutoMapper.Mapper.Map(blogs, blogsDTO);
            return blogsDTO;
        }
    }
}