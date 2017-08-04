using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 页面跳转提示
        /// </summary>
        /// <param name="message">提示文本</param>
        protected virtual void Notification(string message)
        {
            TempData["notification"] = message;
            TempData["notification"] = new List<string>();
            ((List<string>)TempData["notification"]).Add(message);
        }

    }
}