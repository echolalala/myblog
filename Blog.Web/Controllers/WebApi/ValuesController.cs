using Autofac;
using Blog.Core.Blogs;
using Blog.Service.Blogs;
using Blog.Web.Extension;
using Blog.Web.Infrastructure;
using Blog.Web.Models_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class ValuesController : ApiController
    {
        
        public List<BlogSummary> GetInfo()
        {
            var blogPostService = DependencyResolver.Current.GetServices<IBlogPostService>().FirstOrDefault();

            var list = blogPostService.Table.ToList().Select(x =>
            {
                BlogSummary model = new BlogSummary();
                model.Author = "chuanbin";
                model.Content = x.CommentText;
                model.CTime = x.CreatedTime;
                model.ID = x.Id;
                model.Tittle = x.Tittle;
                return model;
            }).ToList();



            return list;
        }

    }
}