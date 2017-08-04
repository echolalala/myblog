using Blog.Core.Blogs;
using Blog.Service.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IBlogPostService _blogPostService;
        private readonly ICommentService _commentService;
        public AdminController(IBlogPostService _blogPostService, ICommentService _commentService)
        {
            this._blogPostService = _blogPostService;
            this._commentService = _commentService;
        }
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            var blogList = _blogPostService.Table.ToList();

            return View(blogList);
        }

        public ActionResult AddBlog(int id = 0)
        {
            if (id == 0)
            {
                return View();
            }

            else
            {
                var model = _blogPostService.Table.Where(x => x.Id == id).FirstOrDefault();
                return View(model);
            }

        }

        [HttpPost]
        [ValidateInput(false)]
        public string Save()
        {
            string Id = Request["Id"];
            int res = 0;
            if (string.IsNullOrEmpty(Id))
            {
                BlogPost blog = new BlogPost();
                blog.Tittle = Request["Tittle"];
                blog.CommentText = Request["CommentText"];
                blog.CommentRichText = Request["CommentRichText"];
                blog.CategoryId = Convert.ToInt32(Request["Category"]);
                blog.KeyWord = Request["KeyWord"];
                blog.Customer_Id = 1;
                blog.CreatedTime = DateTime.Now;
                res = _blogPostService.Add(blog);
            }
            else
            {
                int id = Convert.ToInt32(Id);
                var blog = _blogPostService.Table.Where(x => x.Id == id).FirstOrDefault();
                blog.Tittle = Request["Tittle"];
                blog.CommentText = Request["CommentText"];
                blog.CommentRichText = Request["CommentRichText"];
                blog.CategoryId = Convert.ToInt32(Request["Category"]);
                blog.KeyWord = Request["KeyWord"];
                res = _blogPostService.Update(blog);
            }
            if (res > 0)
                return "保存成功";
            return "保存失败";

        }


        public ActionResult Ceshi()
        {
            return View();
        }


        public ActionResult DeleteBlog(int id)
        {
            try
            {
                var blog = _blogPostService.Table.Where(x => x.Id == id).FirstOrDefault();
                if (blog != null)
                {
                    var commentList = _commentService.Table.Where(x => x.BlogId == id).ToList();
                    var res = _commentService.Delete(commentList);
                    var res2 = _blogPostService.Delete(blog);
                    Notification("删除成功！");
                    return RedirectToAction("Index");
                }
                else
                {
                    Notification("未找到当前文章信息");
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Notification(ex.ToString());
                return RedirectToAction("Index");
            }
        }

    }
}