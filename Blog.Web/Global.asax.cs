using Blog.Core.Blogs;
using Blog.Data;
using Blog.Web.Extension;
using Blog.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Blog.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //初始化数据库
            //策略一：数据库不存在时重新创建数据库
            //Database.SetInitializer<EFDbContext>(new CreateDatabaseIfNotExists<EFDbContext>());
            //策略二：每次启动应用程序时创建数据库
            //Database.SetInitializer<testContext>(new DropCreateDatabaseAlways<testContext>());
            //策略三：模型更改时重新创建数据库
            //Database.SetInitializer<testContext>(new DropCreateDatabaseIfModelChanges<testContext>());
            //策略四：从不创建数据库
            //Database.SetInitializer<EFDbContext>(null);

            DatabaseInitializer.Initialize();

            //依赖注入
            AutofacEngine.RegisterAutofac();

            //AutoMapper注册
            RegisterAutomapper.Excute();

            //WebApi注册
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
        }
    }
}
