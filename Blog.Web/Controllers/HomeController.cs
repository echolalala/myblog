using Autofac;
using Blog.Service.Blogs;
using Blog.Service.Customers;
using Blog.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IBlogPostService _blogComentService;

        public HomeController(
            ICustomerService _customerService,
            IBlogPostService _blogComentService)
        {
            this._blogComentService = _blogComentService;
            this._customerService = _customerService;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}