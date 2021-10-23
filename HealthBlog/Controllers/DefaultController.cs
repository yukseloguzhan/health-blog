using HealthBlog.Bussiness.Concrete;
using HealthBlog.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace HealthBlog.Controllers
{
    public class DefaultController : Controller
    {

        WrongManager wrongManager = new WrongManager(new EfWrongDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string title,int sayfa = 1)
        {
            var list = contentManager.ContentListByTitle(title).ToPagedList(sayfa,5);
            return View(list);
        }


        public ActionResult BlogContent(int sayfa=1)
        {
            var list = contentManager.GetContentList().ToPagedList(sayfa, 5);
            return View(list);
        }

        public PartialViewResult WellKnownMistakes()
        {
            var liste = wrongManager.GetWrongList();
            return PartialView(liste);
        }

        public PartialViewResult RecentlyPosts()
        {
            var liste = contentManager.GetContentList().Take(3).OrderByDescending(x=>x.ContentDate);   //düzelt
            return PartialView(liste);
        }

    }
}