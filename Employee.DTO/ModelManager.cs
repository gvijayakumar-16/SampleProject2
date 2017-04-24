using Microsoft.Extensions.DependencyInjection;

namespace Employee.DTO
{
    public class ModelManager
    {
        public IBlogDTO BlogDTO
        {
            get
            {
                return IOC.Register.ServiceProvider.CreateScope().ServiceProvider.GetService<IBlogDTO>(); ;
            }
        }

        public IPostDTO PostDTO
        {
            get
            {
                return IOC.Register.ServiceProvider.CreateScope().ServiceProvider.GetService<IPostDTO>(); ;
            }
        }
    }
}