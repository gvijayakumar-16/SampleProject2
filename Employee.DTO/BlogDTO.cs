using System.ComponentModel.DataAnnotations;

namespace Employee.DTO
{
    public class BlogDTO
    {
        public int BlogId { get; set; }

        [Required]
        public string Url { get; set; }
    }
}