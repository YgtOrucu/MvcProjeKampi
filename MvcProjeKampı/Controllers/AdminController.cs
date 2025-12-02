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
        private readonly IWriterService _writerService;
        private readonly IHeadingService _headingService;
        public AdminController()
        {
            _categoryService = new CategoryManager(new EFCategoryDal(), new CategoryValitadions());
            _writerService = new WriterManager(new EFWriterDal(), new WriterValitadion());
            _headingService = new HeadingManager(new EFHeadingDal(),new HeadingValidation());
        }
        #endregion

        #region ErrorPage
        public ActionResult ErrorPages()
        {
            return View();
        }
        #endregion

        #region CategoryOperations

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
                TempData["RedirectToAction"] = "Category";
                return RedirectToAction("ErrorPages");
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
            catch (ValidationException ex)
            {
                var errormessage = string.Join("<br>", ex.Errors.Select(x => x.ErrorMessage));
                TempData["ValidationErrors"] = errormessage;
                TempData["RedirectToAction"] = "Category";
                return RedirectToAction("ErrorPages");
            }
        }
        #endregion

        #region WriterOperation
        public ActionResult Writer()
        {
            var values = _writerService.TGetList();
            return View(values);
        }
        [HttpGet]
        public ActionResult WriterAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterAdd(Writer w)
        {
            try
            {
                _writerService.TInsert(w);
                return RedirectToAction("Writer");

            }
            catch (ValidationException ex)
            {
                var errormessage = string.Join("<br>", ex.Errors.Select(x => x.ErrorMessage));
                TempData["ValidationErrors"] = errormessage;
                TempData["RedirectToAction"] = "Writer";
                return RedirectToAction("ErrorPages");
            }
        }

        [HttpGet]
        public ActionResult WriterEdit(int id)
        {
            var getWriter = _writerService.TGetID(id);
            return View("WriterEdit", getWriter);
        }
        [HttpPost]
        public ActionResult WriterUpdate(Writer w)
        {
            try
            {
                var updatedWriter = _writerService.TGetID(w.WriterID);
                updatedWriter.WriterName = w.WriterName;
                updatedWriter.WriterSurname = w.WriterSurname;
                updatedWriter.WriterImage = w.WriterImage;
                updatedWriter.WriterMail = w.WriterMail;
                updatedWriter.WriterPassword = w.WriterPassword;
                updatedWriter.WriterAbout = w.WriterAbout;
                updatedWriter.WriterStatus = w.WriterStatus;
                _writerService.TUpdate(updatedWriter);
                return RedirectToAction("Writer");
            }
            catch (ValidationException ex)
            {
                var errormessage = string.Join("<br>", ex.Errors.Select(x => x.ErrorMessage));
                TempData["ValidationErrors"] = errormessage;
                TempData["RedirectToAction"] = "Writer";
                return RedirectToAction("ErrorPages");
            }
        }
        #endregion

        #region HeadingOperations
        public ActionResult Heading()
        {
            var values = _headingService.TGetList();
            return View(values);
        }
        [HttpGet]
        public ActionResult HeadingAdd()
        {
            #region CategoryListForDropDown
            List<SelectListItem> selectListItemsCategory = new List<SelectListItem>();
            var categories = _categoryService.TListCategorytoIDandNameforWriterTable();

            foreach (var item in categories)
            {
                selectListItemsCategory.Add(new SelectListItem
                {
                    Value = item.CategoryID.ToString(),
                    Text = item.CategoryName
                });
            }
            ViewBag.Categories = selectListItemsCategory;
            #endregion

            #region WriterListForDropDown
            List<SelectListItem> selectListItemsWriter = new List<SelectListItem>();
            var writer = _writerService.TListWritertoIDandNameforWriterTable();
            foreach (var item in writer)
            {
                selectListItemsWriter.Add(new SelectListItem
                {
                    Value = item.WriterID.ToString(),
                    Text = item.WriterName + " " + item.WriterSurname
                });
            }
            ViewBag.Writer = selectListItemsWriter;
            #endregion

            return View();
        }
        [HttpPost]
        public ActionResult HeadingAdd(Heading h) 
        {
            try
            {
                _headingService.TInsert(h);
                return RedirectToAction("Heading");

            }
            catch (ValidationException ex)
            {
                var errormessage = string.Join("<br>", ex.Errors.Select(x => x.ErrorMessage));
                TempData["ValidationErrors"] = errormessage;
                TempData["RedirectToAction"] = "Heading";
                return RedirectToAction("ErrorPages");
            }
        }
        #endregion
    }
}