using AutoMapper;
using Employee.DTO;

namespace Employee
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<IBlogDTO, ViewModels.Blogs.BlogModel>();
            CreateMap<ViewModels.Blogs.BlogModel, IBlogDTO>();
        }
    }
}