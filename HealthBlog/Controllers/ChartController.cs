using HealthBlog.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthBlog.Controllers
{
    public class ChartController : Controller
    {
        HealthContext context = new HealthContext();

        public ActionResult Statistics()
        {

            var deger1 = context.Contents.Count();   // toplam içerik sayısı
            ViewBag.dgr1 = deger1;

            var deger2 = context.Categories.Count();   // toplam kategori sayısı
            ViewBag.dgr2 = deger2;

            var deger3 = context.Writers.Count();   // toplam yazar sayısı
            ViewBag.dgr3 = deger3;
           

            var Siniflar =
               context.Contents.OrderBy(x => x.CategoryId)
                         .GroupBy(x => x.CategoryId)
                         .Select(y => new { Sinif = y.Key, Count = y.Count() });

            var  d = Siniflar.OrderByDescending(c=>c.Count).FirstOrDefault();
            var key = d.Sinif;
            var count = d.Count;
            var category = context.Categories.FirstOrDefault(c=>c.CategoryId == key);
            ViewBag.dgr4 = category.CategoryName;
            ViewBag.dgr5 = count;


            var Writers =
             context.Contents.OrderBy(x => x.WriterId)
             .GroupBy(x => x.WriterId)
             .Select(y => new { Sinif = y.Key, Count = y.Count() });

            var row = Writers.OrderByDescending(c => c.Count).FirstOrDefault();
            var WriterKey = row.Sinif;
            var WriterCount = row.Count;
            var writer = context.Writers.FirstOrDefault(c => c.WriterId == WriterKey);
            ViewBag.dgr6 = writer.WriterTitle + " " + writer.WriterName + " " + writer.WriterSurname;
            ViewBag.dgr7 = count;

            var todayContent = context.Contents.Where(x => x.ContentDate == DateTime.Now).ToList().Count();
            ViewBag.dgr8 = todayContent;

            var inbox = context.Messages;
            ViewBag.dgr9 = inbox.Where(x => x.MessageDate == DateTime.Now).Count();
            ViewBag.dgr10 = inbox.Count();

            return View();


        }
    }
}