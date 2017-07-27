using Blog.Core.Blogs;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Mapping.Blogs
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            this.ToTable("Category");
            this.HasKey(x => x.Id);
            this.Property(x => x.CategoryName).IsRequired().HasMaxLength(30);
        }
    }
}
