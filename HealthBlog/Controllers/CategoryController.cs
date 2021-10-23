using FluentValidation.Results;
using HealthBlog.Bussiness.Abstract;
using HealthBlog.Bussiness.Concrete;
using HealthBlog.Bussiness.FluentValidation;
using HealthBlog.DataAccess.Concrete.EntityFramework;
using HealthBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthBlog.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());

        //public CategoryController(ICategoryService categoryService)
        //{
        //    this.categoryService = categoryService;
        //}

        public ActionResult MainIndex()
        {
            var list = _categoryManager.GetCategoryList();
            return View(list);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category c)
        {
            CategoryValidator _categoryValidator = new CategoryValidator();
            ValidationResult results = _categoryValidator.Validate(c);

            if (results.IsValid)
            {
                _categoryManager.CategoryAdd(c);
                return RedirectToAction("MainIndex","Admin");
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


        public ActionResult CategoryDelete(int id)
        {
            var categoryValue = _categoryManager.GetByID(id);
            _categoryManager.CategoryDelete(categoryValue);
            return RedirectToAction("MainIndex","Admin");
        }


        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryValue = _categoryManager.GetByID(id);

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "True", Value = "True", Selected = true });
            items.Add(new SelectListItem { Text = "False", Value = "False" });

            ViewBag.StatusType = items;


            return View(categoryValue);
        }

        [HttpPost]
        public ActionResult EditCategory(Category c)
        {
            _categoryManager.CategoryUpdate(c);
            return RedirectToAction("MainIndex", "Admin");
        }


    }
}