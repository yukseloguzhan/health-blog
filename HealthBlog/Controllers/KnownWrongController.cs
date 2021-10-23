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
    public class KnownWrongController : Controller
    {

        WrongManager _wrongManager = new WrongManager(new EfWrongDal());
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager _writeryManager = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            var list = _wrongManager.GetWrongList().Where(x => x.Status == true).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult EditWrongInformation(int id)
        {
            var value = _wrongManager.GetByID(id);

            SelectList();

            return View(value);
        }

        [HttpPost]
        public ActionResult EditWrongInformation(Wrong c)
        {
            _wrongManager.WrongUpdate(c);
            return RedirectToAction("Index", "KnownWrong");
        }


        [HttpGet]
        public ActionResult AddWrongInformation()
        {
            SelectList();
            return View();
        }

        [HttpPost]
        public ActionResult AddWrongInformation(Wrong wrong)
        {
            //wrong.CreatedDate = DateTime.Parse(DateTime.Now.ToString("0:yyyy - MM - dd"));
            wrong.CreatedDate = DateTime.Now;
            _wrongManager.AddWrong(wrong);
            return RedirectToAction("Index", "KnownWrong");
        }

        public ActionResult DeleteWrong(int id)
        {
            var entity = _wrongManager.GetByID(id);
            _wrongManager.DeleteWrong(entity);
            return RedirectToAction("Index", "KnownWrong");
        }


        private void SelectList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "True", Value = "True", Selected = true });
            items.Add(new SelectListItem { Text = "False", Value = "False" });

            ViewBag.StatusType = items;

            List<SelectListItem> valueCategory = (from x in _categoryManager.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();

            ViewBag.valueCategory = valueCategory;

            List<SelectListItem> valueWriter = (from x in _writeryManager.GetWriterList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurname,
                                                    Value = x.WriterId.ToString()
                                                }).ToList();

            ViewBag.valueWriter = valueWriter;
        }







    }
}