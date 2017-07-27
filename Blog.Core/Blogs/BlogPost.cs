using Blog.Core.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Blogs
{
    public class BlogPost: BaseEntity   
    {
        public string Tittle { get; set; }

        /// <summary>
        /// 博客内容（纯文字）
        /// </summary>
        public string CommentText { get; set; }

        /// <summary>
        /// 博客内容（富文本）
        /// </summary>
        public string CommentRichText { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public string KeyWord { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        public int Customer_Id { get; set; }

        public virtual Customer Customer { get; set; }


        public virtual ICollection<Comment> Comments { get; set; }

        public virtual Category Category { get; set; }
    }
}
