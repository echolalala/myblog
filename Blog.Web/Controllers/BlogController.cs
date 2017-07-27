using Blog.Core.Blogs;
using Blog.Service.Blogs;
using Blog.Web.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogPostService _blogPostService;
        private readonly ICommentService _commentService;
        private readonly ICategoryService _categoryService;
        private readonly IIdentityService _identityService;
        public BlogController(IBlogPostService _blogPostService,
            ICommentService _commentService,
            ICategoryService _categoryService,
            IIdentityService _identityService
            )
        {
            this._blogPostService = _blogPostService;
            this._commentService = _commentService;
            this._categoryService = _categoryService;
            this._identityService = _identityService;
        }
        public ActionResult Index(int? id)
        {

            List<BlogPost> blogList = new List<BlogPost>();
            if (id == null)

                blogList = _blogPostService.Table.ToList();
            else
                blogList = _blogPostService.Table.Where(x => x.CategoryId == id).ToList();

            return View(blogList);
        }

        public ActionResult Note(int? id)
        {
            var blogModel = _blogPostService.Table.Where(x => x.Id == id).FirstOrDefault().ToModel();
            if (id != null)
            {
                return View(blogModel);
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        public ActionResult Comment(int BlogId)
        {
            var identityList = _identityService.Table.ToList();
            List<SelectListItem> drpList = new List<SelectListItem>();
            drpList.Add(new SelectListItem() { Text = "---告诉我你的真实身份---", Value = "-1", Selected = true });

            foreach (var item in identityList)
            {
                SelectListItem sitem = new SelectListItem();
                sitem.Text = item.IdentityName;
                sitem.Value = item.Id.ToString();
                sitem.Selected = false;
                drpList.Add(sitem);
            }

            ViewData["droplist"] = drpList;
            ViewBag.BlogId = BlogId;
            return PartialView();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveComment(Comment comment)
        {
            comment.IpDr = Request.UserHostAddress;
            comment.CreatTime = DateTime.Now;
            int res = _commentService.Add(comment);
            if (res > 0)
                return Content("<script>alert('成功');location.href='/Note/" + comment.BlogId + "'</script>");
            else
                return Content("<script>alert('失败');location.href='/Note/" + comment.BlogId + "'</script>");
        }


        public ActionResult Category()
        {
            var categorise = _categoryService.Table.ToList();
            return PartialView(categorise);
        }
    }
}