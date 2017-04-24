using Employee.DTO;
using System.ComponentModel.DataAnnotations;

namespace Employee.DTOImplementation
{
    public class BlogDTO : IBlogDTO
    {
        public int BlogId { get; set; }

        [Required]
        public string Url { get; set; }
    }
}