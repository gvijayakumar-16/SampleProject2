using AutoMapper;
using Employee.Data.Models;
using Employee.DTO;

namespace Employee.Data
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Blog, BlogDTO>();
            CreateMap<BlogDTO, Blog>();
        }
    }
}