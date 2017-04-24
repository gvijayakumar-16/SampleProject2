using AutoMapper;
using Employee.Data.Models;
using Employee.DTO;
using Employee.DTOImplementation;

namespace Employee.Data
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Blog, IBlogDTO>().ConstructUsing((Blog src) => new BlogDTO());
            CreateMap<IBlogDTO, Blog>();
        }
    }
}