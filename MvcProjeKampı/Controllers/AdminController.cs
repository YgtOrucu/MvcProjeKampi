using BusinessLayer.Abstract;
using BusinessLayer.Concreate;
using BusinessLayer.Valitadions;
using DataAccessLayer.EntityFramawork;
using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampı.Controllers
{
    public class AdminController : Controller
    {
        #region ConstructorMethods
        private readonly ICategoryService _categoryService;
        public AdminController()
        {
            _categoryService = new CategoryManager(new EFCategoryDal(), new CategoryValitadions());
        }
        #endregion

        #region CategoryOperations
        public ActionResult CategoryErrors()
        {
            return View();
        }

        public ActionResult Category()
        {
            var values = _categoryService.TGetList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(Category c)
        {
            try
            {
                _categoryService.TInsert(c);
                return RedirectToAction("Category");

            }
            catch (ValidationException ex)
            {
                var errormessage = string.Join("<br>", ex.Errors.Select(x => x.ErrorMessage));
                TempData["ValidationErrors"] = errormessage;
                return RedirectToAction("CategoryErrors");
            }
        }

        [HttpGet]
        public ActionResult CategoryEdit(int id)
        {
            var getCategory = _categoryService.TGetID(id);
            return View("CategoryEdit", getCategory);
        }
        [HttpPost]
        public ActionResult CategoryUpdate(Category c)
        {
            try
            {
                var updetedCategory = _categoryService.TGetID(c.CategoryID);
                updetedCategory.CategoryName = c.CategoryName;
                updetedCategory.CategoryDescription = c.CategoryDescription;
                updetedCategory.CategoryStatus = c.CategoryStatus;
                _categoryService.TUpdate(updetedCategory);
                return RedirectToAction("Category");
            }
            catch (Exception ex)
            {
                var errormessage = string.Join("<br>", ex.Message.ToString());
                TempData["ValidationErrors"] = errormessage;
                return RedirectToAction("CategoryErrors");
            } 
        }
        #endregion
    }
}