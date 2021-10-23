using HealthBlog.Bussiness.Concrete;
using HealthBlog.DataAccess.Concrete.EntityFramework;
using HealthBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthBlog.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager imageFile = new ImageFileManager(new EfImageFileDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());

        public ActionResult Images()
        {
            var list = imageFile.GetImageFileList();
            return View(list);
        }

        [HttpGet]
        public ActionResult AddImages()
        {
            List<SelectListItem> valueContent = (from x in contentManager.GetContentList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.ContentTitle,
                                                      Value = x.ContentId.ToString()
                                                  }).ToList();

            ViewBag.valueContent = valueContent;



            return View();
        }

        [HttpPost]
        public ActionResult AddImages(ImageFile ımageFile)
        {

            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string _filename = DateTime.Now.ToString("yymmssfff") + filename;
                string path = "~/FrontendFiles/Gallery/" + _filename;
                Request.Files[0].SaveAs(Server.MapPath(path));
                ımageFile.ImagePath = _filename;
            }



            imageFile.AddImageFile(ımageFile);
            return RedirectToAction("AdminImages");
        }


        [HttpGet]
        public ActionResult UpdateImage(int id)
        {
            var value = imageFile.GetImageFile(id);

            List<SelectListItem> valueContent = (from x in contentManager.GetContentList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.ContentTitle,
                                                     Value = x.ContentId.ToString()
                                                 }).ToList();

            ViewBag.valueContent = valueContent;

            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateImage(ImageFile c)
        {

            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string _filename = DateTime.Now.ToString("yymmssfff") + filename;
                string path = "~/FrontendFiles/Gallery/" + _filename;
                Request.Files[0].SaveAs(Server.MapPath(path));
                c.ImagePath = _filename;
            }

            imageFile.UpdateImageFile(c);
            return RedirectToAction("AdminImages");
        }


        public ActionResult AdminImages()
        {
            var imageFiles = imageFile.GetImageFileList();
            return View(imageFiles);
        }


        public ActionResult DeleteImageFile(int id)
        {
            var entity = imageFile.GetImageFile(id);
            imageFile.DeleteImageFile(entity);
            return RedirectToAction("AdminImages");
        }

        public ActionResult DenemeSil()
        {
            var list = imageFile.GetImageFileList();
            return View(list);
        }

        public ActionResult DenemeSil2()
        {
           
            return View();
        }

        public ActionResult GaleriGuzel()
        {

            return View();
        }

        public ActionResult GalerySlider()
        {

            return View();
        }

        public PartialViewResult Slider(int id)
        {
            var  list = imageFile.ImageFileListByContent(id);
            return PartialView(list);
        }

    }
}