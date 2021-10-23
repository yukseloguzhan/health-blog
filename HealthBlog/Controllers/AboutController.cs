using HealthBlog.Bussiness.Concrete;
using HealthBlog.DataAccess.Concrete.EntityFramework;
using HealthBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace HealthBlog.Controllers
{
    public class AboutController : Controller
    {

        AboutManager aboutManager = new AboutManager(new EfAboutDal());

        public ActionResult AboutUs()
        {
            var about = aboutManager.GetAbout();
            return View(about);
        }

        public ActionResult AboutUsContents(int sayfa=1)
        {
            var list  = aboutManager.GetAboutList().ToPagedList(sayfa,2);
            return View(list);
        }


        [HttpGet]
        public ActionResult AddAboutContent()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "True", Value = "True", Selected = true });
            items.Add(new SelectListItem { Text = "False", Value = "False" });

            ViewBag.StatusType = items;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddAboutContent(About about)
        {
            about.CreatedDate = DateTime.Now;

            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files["AboutImage"].FileName);
                string _filename = DateTime.Now.ToString("yymmssfff") + filename;
                string path = "~/FrontendFiles/AdminAbout/AboutImages/" + _filename;
                Request.Files["AboutImage"].SaveAs(Server.MapPath(path));
                about.AboutImage = _filename;
            }

            aboutManager.AboutAdd(about);
            return RedirectToAction("AboutUsContents");
        }

        [HttpGet]
        public ActionResult EditAboutContent(int id)
        {
            var about = aboutManager.GetByID(id);

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "True", Value = "True", Selected = true });
            items.Add(new SelectListItem { Text = "False", Value = "False" });

            ViewBag.StatusType = items;
            return View(about);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditAboutContent(About about)
        {
            about.CreatedDate = DateTime.Now;

            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files["AboutImage"].FileName);
                string _filename = DateTime.Now.ToString("yymmssfff") + filename;
                string path = "~/FrontendFiles/AdminAbout/AboutImages/" + _filename;
                Request.Files["AboutImage"].SaveAs(Server.MapPath(path));
                about.AboutImage = _filename;
            }

            aboutManager.AboutUpdate(about);
            return RedirectToAction("AboutUsContents");
        }

        public ActionResult DeleteAboutContent(int id)
        {
            var entity = aboutManager.GetByID(id);
            aboutManager.AboutDelete(entity);
            return RedirectToAction("AboutUsContents");
        }

        public ActionResult MakeActive(int id)
        {
            aboutManager.AboutContentActive(id);
            return RedirectToAction("AboutUsContents");
        }

    }
}