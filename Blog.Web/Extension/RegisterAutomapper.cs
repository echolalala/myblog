using AutoMapper;
using Blog.Core.Blogs;
using Blog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Extension
{
    public class RegisterAutomapper
    {
        public static void Excute()
        {
            Mapper.CreateMap<BlogModel, BlogPost>();
            Mapper.CreateMap<BlogPost, BlogModel>()
                .ForMember(x => x.CommentList, y => y.MapFrom(entity => entity.Comments))
                .ForMember(x => x.Author, y => y.MapFrom(entity => entity.Customer.Username));


            
        }
    }
}