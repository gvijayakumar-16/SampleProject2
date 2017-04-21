namespace Employee.DTO
{
    public class ModelManager
    {
        public BlogDTO BlogDTO
        {
            get
            {
                return new BlogDTO();
            }
        }

        public PostDTO PostDTO
        {
            get
            {
                return new PostDTO();
            }
        }
    }
}
