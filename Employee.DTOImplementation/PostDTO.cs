using Employee.DTO;

namespace Employee.DTOImplementation
{
    public class PostDTO : IPostDTO
    {
        public int PostId { get; set; }
        public int BlogId { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
    }
}