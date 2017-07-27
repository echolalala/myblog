using AutoMapper;
using Blog.Core.Blogs;
using Blog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Extension
{
    public static class MapperExtentions
    {
        public static BlogModel ToModel(this BlogPost entity)
        {
            return Mapper.Map<BlogPost, BlogModel>(entity);
        }
        public static BlogPost ToEntity(this BlogModel model)
        {
            return Mapper.Map<BlogModel, BlogPost>(model);
        }
    }
}