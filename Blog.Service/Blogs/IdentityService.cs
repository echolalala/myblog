﻿//zssssssssssssssssssssssssssss
using Blog.Core.Blogs;
using Blog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Blogs
{
   public  class IdentityService:Repository<Identity>, IIdentityService
    {
    }
}
