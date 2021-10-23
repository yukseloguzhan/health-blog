using HealthBlog.Bussiness.Concrete;
using HealthBlog.DataAccess.Concrete.EntityFramework;
using HealthBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace HealthBlog.Controllers
{
    public class CategoriesPageController : Controller
    {

        //CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());


        public ActionResult Index()
        {
            var list = contentManager.GetContentList();

            IEnumerable<IGrouping<string, Content>> groups = list.GroupBy(x => x.Category.CategoryName);

            ViewBag.counter = list.Count();
            ViewBag.list = list;

            return View(groups);
        }

        public ActionResult CategoryDetail(int id,int sayfa=1)
        {
             var list = contentManager.ContentListByCategoryId(id).ToPagedList(sayfa, 2);
             var title = contentManager.ContentByCategoryId(id);
             ViewBag.categoryname = title.Category.CategoryName; 

            return View(list);
        }

        public PartialViewResult RecentlyPost()
        {
            IEnumerable<Content> list = contentManager.GetContentList().OrderByDescending(x => x.ContentDate).Take(5);
            return PartialView(list);
        }

        public PartialViewResult TwelveContents()
        {
            IEnumerable<Content> list = contentManager.GetContentList().OrderByDescending(x => x.ContentDate).Take(12);
            return PartialView(list);
        }

        public PartialViewResult ReadMore()
        {
            IEnumerable<Content> list = contentManager.GetContentList().OrderBy(x => x.ContentDate).Take(12);
            return PartialView(list);
        }

    }
}