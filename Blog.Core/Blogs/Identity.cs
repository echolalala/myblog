using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Blogs
{
    public class Identity : BaseEntity
    {
        public string IdentityName { get; set; }

        public string ImgPath { get; set; }


        public virtual ICollection<Comment> Comments { get; set; }
    }
}
