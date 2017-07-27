using Blog.Core.Customers;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Mapping.Customers
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            this.ToTable("Customer");
            this.HasKey(x => x.Id);

            this.Property(x => x.Username).IsRequired().HasMaxLength(20);
            this.Property(x => x.Password).IsRequired().HasMaxLength(100);
        }
    }
}
