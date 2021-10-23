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
using System.IO;

namespace HealthBlog.Controllers
{
    public class ContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager _writeryManager = new WriterManager(new EfWriterDal());


        public ActionResult Index(/*int sayfa=1*/)
        {
            //var list = contentManager.GetContentList().ToPagedList(sayfa,7);
            var list = contentManager.GetContentList();
            return View(list);
        }

        public ActionResult ContentListByCategoryId(int id)
        {
            var liste = contentManager.ContentListByCategoryId(id);
            var content = liste.FirstOrDefault();
            ViewBag.category = content.Category.CategoryName;
            return View(liste);
        }


        [HttpGet]
        public ActionResult EditContent(int id)
        {
            var content = contentManager.GetByID(id);

            SelectList();

            return View(content);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditContent(Content content)
        {
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files["ContentImage"].FileName);
                string _filename = DateTime.Now.ToString("yymmssfff") + filename;
                string path = "~/FrontendFiles/ContentImages/" + _filename;
                Request.Files["ContentImage"].SaveAs(Server.MapPath(path));
                content.ContentImage = _filename;
            }

            contentManager.ContentUpdate(content);
            return RedirectToAction("AdminContents"); // hata veriyor sadece yönlendiremiyorum sayfaya
        }


        [HttpGet]
        public ActionResult AddContent()
        {
            SelectList();
            return View();
        }

        public ActionResult ContentListByWriter(int id)
        {
            var list = contentManager.ContentListByWriterId(id);
            var writer = list.FirstOrDefault();
            ViewBag.writer = writer.Writer.WriterTitle + " " + writer.Writer.WriterName + " " + writer.Writer.WriterSurname; 
            return View(list);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddContent(Content content)
        {
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files["ContentImage"].FileName);
                string _filename = DateTime.Now.ToString("yymmssfff") + filename;
                string path = "~/FrontendFiles/ContentImages/" + _filename;
                Request.Files["ContentImage"].SaveAs(Server.MapPath(path));
                content.ContentImage = _filename;
            }

            content.ContentDate = DateTime.Now;
            contentManager.ContentAdd(content);
            return RedirectToAction("AdminContents");
        }

        public ActionResult DeleteContent(int id)
        {
            var entity = contentManager.GetByID(id);
            contentManager.ContentDelete(entity);
            //return RedirectToAction("Index","Content");   // herşey doğru siliyor ama sayfaya yönlendirme de sorun var 
            return RedirectToAction("AdminContents");   // herşey doğru siliyor ama sayfaya yönlendirme de sorun var 
        }

        public ActionResult AdminContents()
        {
            var list = contentManager.GetContentList();
            return View(list);
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

        public ActionResult ContentReport()
        {
            var contentValues = contentManager.GetContentList();
            return View(contentValues);

        }


    }
}