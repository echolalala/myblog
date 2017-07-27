using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Blogs
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public virtual ICollection<BlogPost> BlogList { get; set; }
    }
}
