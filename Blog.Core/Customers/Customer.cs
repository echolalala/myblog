using Blog.Core.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Customers
{
    public class Customer : BaseEntity
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool Active { get; set; }

        public bool Deleted { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public virtual ICollection<BlogPost> BlogPosts { get; set; }

    }
}
