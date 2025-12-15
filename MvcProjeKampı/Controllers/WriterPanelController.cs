using BusinessLayer.Abstract;
using BusinessLayer.Concreate;
using BusinessLayer.Valitadions;
using DataAccessLayer.Context;
using DataAccessLayer.EntityFramawork;
using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampı.Controllers
{
    public class WriterPanelController : Controller
    {
        MvcKampContext context = new MvcKampContext();
        private readonly IHeadingService _headingService;
        private readonly ICategoryService _categoryService;
        private readonly IMessageService _messageService;
        private readonly IContentService _contentService;

        public WriterPanelController()
        {
            _headingService = new HeadingManager(new EFHeadingDal(), new HeadingValidation());
            _categoryService = new CategoryManager(new EFCategoryDal(), new CategoryValitadions());
            _messageService = new MessageManager(new EFMessageDal(), new MessageValidation());
            _contentService = new ContentManager(new EFContentDal());
        }
        // GET: WriterPanel
        #region ErrorPages
        public ActionResult ErrorPages()
        {
            return View();
        }
        #endregion

        public ActionResult WriterProfile()
        {
            return View();
        }
        #region WriterHeadingOperations
        public ActionResult WriterHeadings()
        {
            int id = 1; //Sesion'dan yazarın ıdsını çekicez login de giriş olduğu zaman 
            var values = _headingService.TGetListByWriter(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult WriterHeadingAdd()
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
            return View();
        }

        [HttpPost]
        public ActionResult WriterHeadingAdd(Heading h)
        {
            try
            {
                h.HeadingStatus = true;
                h.HeadingDate = DateTime.Now;
                h.WriterID = 1; //Sesion'dan yazarın ıdsını çekicez login de giriş olduğu zaman
                _headingService.TInsert(h);
                return RedirectToAction("WriterHeadings");
            }
            catch (ValidationException ex)
            {
                var errormessage = string.Join("<br>", ex.Errors.Select(x => x.ErrorMessage));
                TempData["ValidationErrors"] = errormessage;
                TempData["RedirectToAction"] = "WriterHeadings";
                return RedirectToAction("ErrorPages");
            }
        }

        [HttpGet]
        public ActionResult WriterHeadingEdit(int id)
        {
            var values = context.Categories.Select(x => new SelectListItem
            {
                Value = x.CategoryID.ToString(),
                Text = x.CategoryName
            }).ToList();
            ViewBag.Categories = values;
            var getheading = _headingService.TGetID(id);
            return View("WriterHeadingEdit", getheading);
        }

        [HttpPost]
        public ActionResult WriterHeadingUpdate(Heading h)
        {
            var updatedheading = _headingService.TGetID(h.HeadingID);
            updatedheading.HeadingName = h.HeadingName;
            updatedheading.CategoryID = h.CategoryID;
            updatedheading.HeadingStatus = h.HeadingStatus;
            _headingService.TUpdate(updatedheading);
            return RedirectToAction("WriterHeadings");
        }
        #endregion

        #region WriterMessageOperations

        public PartialViewResult LeftBarArea()
        {
            return PartialView();
        }

        public ActionResult WriterMessageInbox()
        {
            var Inboxlist = _messageService.TListInboxForAdminUser();
            return View(Inboxlist);
        }

        public ActionResult WriterMessageSend()
        {
            var Sendlist = _messageService.TListSenderForAdminUser();
            return View(Sendlist);
        }

        public ActionResult WriterMessagDetails(int id)
        {
            var getmessagedetails = _messageService.TGetID(id);
            return View(getmessagedetails);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message m)
        {
            try
            {
                m.SenderMail = "gizem@gmail.com"; //Sesion'dan yazarın ıdsını çekicez login de giriş olduğu zaman 
                m.MessageDate = DateTime.Now;
                _messageService.TInsert(m);
                return RedirectToAction("WriterMessageSend");

            }
            catch (ValidationException ex)
            {
                var errormessage = string.Join("<br>", ex.Errors.Select(x => x.ErrorMessage));
                TempData["ValidationErrors"] = errormessage;
                TempData["RedirectToAction"] = "NewMessage";
                return RedirectToAction("ErrorPages");
            }
        }
        #endregion

        #region WriterContentOperations
        public ActionResult WriterContentByHeading(int id)
        {
            var headingdata = _headingService.TGetID(id);
            string headingTitle = headingdata.HeadingName;

            var ContentByHeading = _contentService.TGetListContentByHeading(id);
            if (ContentByHeading.Count != 0)
            {
                return View(ContentByHeading);
            }
            else
            {
                TempData["ValidationErrors"] = $"{headingTitle} başlığına ait bir içerik bulunamamıştır";
                TempData["RedirectToAction"] = "WriterHeadings";
                return View("ErrorPages");
            }
        }
        #endregion

    }
}