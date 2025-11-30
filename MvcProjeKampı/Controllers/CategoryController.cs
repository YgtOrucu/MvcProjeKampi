using BusinessLayer.Abstract;
using BusinessLayer.Concreate;
using BusinessLayer.Valitadions;
using DataAccessLayer.EntityFramawork;
using System;
using System.Collections.Generic;
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
        public ActionResult Index()
        {
            var values = _categoryService.TGetList();
            return View(values);
        }
    }
}