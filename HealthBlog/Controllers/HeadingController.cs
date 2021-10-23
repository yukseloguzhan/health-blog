using HealthBlog.Bussiness.Concrete;
using HealthBlog.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthBlog.Controllers
{
    public class HeadingController : Controller
    {
        /*
        HeadingManager _headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());

        public ActionResult Index()
        {
            var list = _headingManager.GetHeadingList();
            return View(list);
        }
        
        public ActionResult HeadingListByCategoryId(int id)
        {
            var liste = _headingManager.HeadingListByCategoryId(id);
            var category = _categoryManager.GetByID(id);
            ViewBag.category = category.CategoryName;
            return View(liste);
        }

        public ActionResult HeadingListByWriter(int id)
        {
            var liste = _headingManager.HeadingListByWriterId(id);
            return View(liste);
        }*/

    }
}