using Blog.Core.Blogs;
using Blog.Core.Customers;
using Blog.Data.Mapping.Blogs;
using Blog.Data.Mapping.Customers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data
{
    public class EFDbContext : DbContext
    {
        public EFDbContext()
            : base("EFDbContext") { }


        public EFDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString) { }


        public DbSet<Customer> Customer { get; set; }
        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Identity> Identity { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new BlogPostMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new IdentityMap());

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();  //表中都统一设置禁用一对多级联删除
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>(); //表中都统一设置禁用多对多级联删除

            base.OnModelCreating(modelBuilder);
        }
    }
}
