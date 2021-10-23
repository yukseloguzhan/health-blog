using HealthBlog.Bussiness.Abstract;
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
    public class AdminController : Controller
    {

        CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());

        public ActionResult MainIndex(int sayfa=1)
        {
            var list = _categoryManager.GetCategoryList().ToPagedList(sayfa,8);
            return View(list);
        }




    }
}