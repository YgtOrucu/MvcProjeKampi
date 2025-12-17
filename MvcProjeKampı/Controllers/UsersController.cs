using BusinessLayer.Abstract;
using BusinessLayer.Concreate;
using BusinessLayer.Valitadions;
using DataAccessLayer.Context;
using DataAccessLayer.EntityFramawork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampı.Controllers
{
    public class UsersController : Controller
    {
        #region ConstructorMethods
        MvcKampContext context = new MvcKampContext();
        private readonly IHeadingService _headingService;
        private readonly IContentService _contentService;
        public UsersController()
        {
            _headingService = new HeadingManager(new EFHeadingDal(), new HeadingValidation());
            _contentService = new ContentManager(new EFContentDal());
        }
        #endregion

        #region ErrorPages
        public PartialViewResult ErrorPages()
        {
            return PartialView();
        }

        #endregion
        public ActionResult Heading()
        {
            var values = _headingService.TListTheTRUEHeadingsForUsers();
            return View(values);
        }

        public PartialViewResult Content()
        {
            var values = _contentService.TListContentTheOnesWithTheTrueHeading();
            return PartialView(values);
        }

        public PartialViewResult ContentByHeading(int id)
        {
            var headingdata = _headingService.TGetID(id);
            string headingTitle = headingdata.HeadingName;

            var ContentByHeading = _contentService.TGetListContentByHeading(id);
            if (ContentByHeading.Count != 0)
            {
                return PartialView(ContentByHeading);
            }
            else
            {
                TempData["ValidationErrors"] = $"{headingTitle} başlığına ait bir içerik bulunamamıştır";
                TempData["RedirectToAction"] = "Heading";
                return PartialView("ErrorPages");
            }
        }
    }
}