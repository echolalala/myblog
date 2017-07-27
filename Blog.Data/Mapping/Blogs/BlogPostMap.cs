using Blog.Core.Blogs;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Mapping.Blogs
{
    public class BlogPostMap:EntityTypeConfiguration<BlogPost>
    {
        public BlogPostMap()
        {
            this.ToTable("BlogPost");
            this.HasKey(x => x.Id);
            this.Property(x => x.Tittle).IsRequired().HasMaxLength(30);
            this.Property(x => x.KeyWord).IsOptional().HasMaxLength(50);
            this.HasRequired(x => x.Customer).WithMany(x => x.BlogPosts).HasForeignKey(x => x.Customer_Id);
            this.HasRequired(x => x.Category).WithMany(x => x.BlogList).HasForeignKey(x => x.CategoryId);
        }
    }
}
