using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Blogs
{
    public class Comment:BaseEntity
    {
        /// <summary>
        /// 评论内容
        /// </summary>
        public string CommentText { get; set; }

        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime CreatTime { get; set; }

        /// <summary>
        /// 回复ID
        /// </summary>
        public int? ReplyId { get; set; }

        /// <summary>
        /// Ip地址
        /// </summary>
        public string IpDr { get; set; }

        /// <summary>
        /// 身份ID
        /// </summary>
        public int IdentityId { get; set; }

        /// <summary>
        /// 博客Id
        /// </summary>
        public int BlogId { get; set; }

        public virtual BlogPost Blog { get; set; }


        public virtual Identity Identity { get; set; }

    }
}
