using FluentValidation.Results;
using HealthBlog.Bussiness.Concrete;
using HealthBlog.Bussiness.FluentValidation;
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
    public class WriterController : Controller
    {

        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();


        public ActionResult Index()
        {
            var list = writerManager.GetWriterList();
            return View(list);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer w)
        {

            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string _filename = DateTime.Now.ToString("yymmssfff") + filename;
                string path = "~/FrontendFiles/WriterImages/" + _filename;
                Request.Files[0].SaveAs(Server.MapPath(path));
                w.WriterImage = _filename;
            }

            ValidationResult results = writerValidator.Validate(w);
            if (results.IsValid)
            {
            writerManager.WriterAdd(w);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writerValue = writerManager.WriterGetById(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer w)
        {
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string _filename = DateTime.Now.ToString("yymmssfff") + filename;
                string path = "~/FrontendFiles/WriterImages/" + _filename;
                Request.Files[0].SaveAs(Server.MapPath(path));
                w.WriterImage = _filename;
            }

            ValidationResult results = writerValidator.Validate(w);
            if (results.IsValid)
            {
                writerManager.WriterUpdate(w);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();

        }

        public ActionResult DeleteWriter(int id)
        {
            var writerValue = writerManager.WriterGetById(id);
            writerManager.WriterDelete(writerValue);
            return RedirectToAction("Index");
        }

        public ActionResult WritersPage(int sayfa=1)
        {
            var list = writerManager.GetWriterList().ToPagedList(sayfa,6);
            return View(list);
        }

        public ActionResult WriterDetail(int id)
        {
            var writer = writerManager.WriterGetById(id);
            return View(writer);
        }

    }
}