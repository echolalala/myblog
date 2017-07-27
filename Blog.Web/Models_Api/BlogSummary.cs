using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Models_Api
{
    public class BlogSummary
    {
        public int ID { get; set; }

        public string  Tittle { get; set; }

        public string Content { get; set; }
    
        public DateTime CTime { get; set; }

        public string Author { get; set; }

    }
}