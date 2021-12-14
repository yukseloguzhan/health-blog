using HealthBlog.Bussiness.Concrete;
using HealthBlog.DataAccess.Concrete.EntityFramework;
using HealthBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthBlog.Controllers
{
    public class CommentController : Controller
    {

        CommentManager commentManager = new CommentManager(new EfCommentDal());

        [HttpGet]
        public PartialViewResult AddComment(int id)
        {
            ViewBag.contentId = id;
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddComment(Comment comment)
        {
            comment.CreateDate = DateTime.Now;
            commentManager.CommentAdd(comment);
            return RedirectToAction("BlogContent", "Default");
        }

        public ActionResult AdminCommentList()
        {
            var list = commentManager.GetCommentList().OrderByDescending(x=>x.CreateDate);
            return View(list);
        }

        public ActionResult AdminDeleteComment(int id)
        {
            var entity = commentManager.GetByID(id);
            commentManager.CommentDelete(entity);
            return RedirectToAction("AdminCommentList");
        }


        public ActionResult Popup(int id)
        {

            return View(commentManager.GetByID(id));
        }

        public ActionResult Popup2(int id)
        {
            var entity = commentManager.GetByID(id);
            return PartialView(entity);
        }

    }
}