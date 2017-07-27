using Autofac;
using Autofac.Integration.Mvc;
using Blog.Data;
using Blog.Service.Blogs;
using Blog.Service.Customers;
using System.Reflection;
using System.Web.Http.Dependencies;
using System.Web.Mvc;

namespace Blog.Web.Infrastructure
{
    public class AutofacEngine
    {
        /// <summary>
        /// 注册容器
        /// </summary>
        public static IContainer Container;
        public static void RegisterAutofac()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            #region IOC注册区域
            //参数模式的注入
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            //Admin
            builder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerLifetimeScope();
            builder.RegisterType<BlogPostService>().As<IBlogPostService>().InstancePerLifetimeScope();
            builder.RegisterType<CommentService>().As<ICommentService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<IdentityService>().As<IIdentityService>().InstancePerLifetimeScope();
            #endregion
            // then
            Container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));

            
        }

    }
}