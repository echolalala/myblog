using Blog.Core.Blogs;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Mapping.Blogs
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            this.ToTable("Comment");
            this.HasKey(x => x.Id);
            this.Property(x => x.CreatTime).IsRequired();
            this.Property(x => x.IdentityId).IsRequired();
            this.HasRequired(x => x.Blog).WithMany(x => x.Comments).HasForeignKey(x => x.BlogId);
            this.HasRequired(x => x.Identity).WithMany(x => x.Comments).HasForeignKey(x => x.IdentityId);
        }
    }
}
