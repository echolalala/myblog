using Blog.Core.Blogs;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Mapping.Blogs
{
    public class IdentityMap : EntityTypeConfiguration<Identity>
    {
        public IdentityMap()
        {
            this.ToTable("Identity");
            this.HasKey(x => x.Id);
            this.Property(x => x.IdentityName).IsRequired().HasMaxLength(30);
            this.Property(x => x.ImgPath).IsRequired().HasMaxLength(200);
        }
    }
}
