using Blog.Core.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Models
{
    public class BlogModel
    {
        public int Id { get; set; }
        public string Tittle { get; set; }

        /// <summary>
        /// 博客内容（富文本）
        /// </summary>
        public string CommentRichText { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public string KeyWord { get; set; }


        /// <summary>
        /// 作者名
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }


        public List<Comment> CommentList { get; set; }

    }
}