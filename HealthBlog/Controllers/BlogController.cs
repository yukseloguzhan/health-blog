using HealthBlog.Bussiness.Concrete;
using HealthBlog.DataAccess.Concrete.EntityFramework;
using HealthBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthBlog.Controllers
{
    public class BlogController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
        CommentManager commentManager = new CommentManager(new EfCommentDal());


        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult CategoryList()
        {
            IEnumerable<Category> list = categoryManager.GetCategoryList().Take(8);
            int[] dizi = new int[8];
            int k = 0;


            foreach (var item in list)
            {

                dizi[k] = contentManager.NumberOfContentByCategory(item.CategoryId);
                k++;

            }

            ViewBag.counter = dizi;
            return PartialView(list);
        }


        public PartialViewResult RecentlyPost()
        {
            IEnumerable<Content> list = contentManager.GetContentList().OrderByDescending(x => x.ContentDate).Take(5);
            return PartialView(list);
        }


        public ActionResult BlogSingle(int id)
        {
            var content = contentManager.GetByID(id);
            return View(content);
        }

        public PartialViewResult Comments(int id)
        {
            //IEnumerable<Content> list = contentManager.GetContentList().OrderByDescending(x => x.ContentDate).Take(5);
            List<Comment> list = commentManager.CommentsByContent(id);
            ViewBag.total = list.Count();
            return PartialView(list);
        }



    }
}