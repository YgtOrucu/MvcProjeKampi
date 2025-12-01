using BusinessLayer.Abstract;
using BusinessLayer.Concreate;
using BusinessLayer.Valitadions;
using DataAccessLayer.EntityFramawork;
using EntityLayer.Concreate;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using FluentValidation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampı.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private readonly ICategoryService _categoryService;
        public CategoryController()
        {
            _categoryService = new CategoryManager(new EFCategoryDal(), new CategoryValitadions());
        }
        public ActionResult CategoryList()
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
                return RedirectToAction("CategoryList");
            }
            catch (ValidationException ex)
            {
                var errormessage = string.Join("<br>", ex.Errors.Select(x => x.ErrorMessage));
                TempData["ValidationErrors"] = errormessage;
                return RedirectToAction("CategoryAddError");
            }
        }
        public ActionResult CategoryAddError()
        {
            return View();
        }
    }
}