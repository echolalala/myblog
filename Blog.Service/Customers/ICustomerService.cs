using Blog.Core.Customers;
using Blog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Customers
{
   public  interface ICustomerService : IRepository<Customer>
    {
        string Ceshi();
    }
}
