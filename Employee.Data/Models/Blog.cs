using System;
using System.Collections.Generic;

namespace Employee.Data.Models
{
    public partial class Blog
    {
        public Blog()
        {
            Post = new HashSet<Post>();
        }

        public int BlogId { get; set; }
        public string Url { get; set; }

        public virtual ICollection<Post> Post { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Url))
            {
                throw new Exception("Error: Url is missing");
            }
        }
    }
}
