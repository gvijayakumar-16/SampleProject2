namespace Employee.DTO
{
    public interface IPostDTO
    {
        int BlogId { get; set; }
        string Content { get; set; }
        int PostId { get; set; }
        string Title { get; set; }
    }
}