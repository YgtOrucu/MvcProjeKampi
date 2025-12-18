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
        #region ConstructorMethods
        MvcKampContext context = new MvcKampContext();
        private readonly IHeadingService _headingService;
        private readonly ICategoryService _categoryService;
        private readonly IMessageService _messageService;
        private readonly IContentService _contentService;
        private readonly IWriterService _writerService;


        public WriterPanelController()
        {
            _headingService = new HeadingManager(new EFHeadingDal(), new HeadingValidation());
            _categoryService = new CategoryManager(new EFCategoryDal(), new CategoryValitadions());
            _messageService = new MessageManager(new EFMessageDal(), new MessageValidation());
            _contentService = new ContentManager(new EFContentDal());
            _writerService = new WriterManager(new EFWriterDal(), new WriterValitadion());
        }
        #endregion

        #region ErrorPages
        public ActionResult ErrorPages()
        {
            return View();
        }
        #endregion

        #region WriterProfile
        public ActionResult WriterProfile()
        {
            var writer = Session["Writer"] as SessionForWriter;
            int writerıd = Convert.ToInt32(writer.WriterID);
            var getwriter = _writerService.TGetID(writerıd);
            return View(getwriter);
        }

        public ActionResult WriterProfileEdit(int id)
        {
            var getwriter = _writerService.TGetID(id);
            return View("WriterProfileEdit", getwriter);
        }

        [HttpPost]
        public ActionResult WriterProfileUpdate(Writer w)
        {
            var updatedwriter = _writerService.TGetID(w.WriterID);

            updatedwriter.WriterImage = w.WriterImage;
            updatedwriter.WriterPassword = w.WriterPassword;
            updatedwriter.WriterAbout = w.WriterAbout;
            _writerService.TUpdate(updatedwriter);
            return RedirectToAction("WriterProfile");
        }
        #endregion

        #region WriterHeadingOperations
        public ActionResult WriterHeadings()
        {
            var writer = Session["Writer"] as SessionForWriter;
            int writerıd = Convert.ToInt32(writer.WriterID);
            var values = _headingService.TGetListByWriter(writerıd);
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
                var writer = Session["Writer"] as SessionForWriter;
                h.HeadingStatus = true;
                h.HeadingDate = DateTime.Now;
                h.WriterID = Convert.ToInt32(writer.WriterID);
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

        public void InboxAndSentForWriterMessageCount()
        {

            var writer = Session["Writer"] as SessionForWriter;
            string mail = writer.WriterMail;
            int getInboxMessageCount = _messageService.TTotalNumberOfWriterInbox(mail);
            int getSendMessageCount = _messageService.TTotalNumberOfWriterSent(mail);
            ViewBag.ınboxcount = getInboxMessageCount;
            ViewBag.sentcount = getSendMessageCount;
        }

        public PartialViewResult LeftBarArea()
        {
            InboxAndSentForWriterMessageCount();
            return PartialView();
        }

        public ActionResult WriterMessageInbox()
        {
            var writer = Session["Writer"] as SessionForWriter;
            string mail = writer.WriterMail;
            var Inboxlist = _messageService.TListInboxForWriterUser(mail);
            return View(Inboxlist);
        }

        public ActionResult WriterMessageSend()
        {
            var writer = Session["Writer"] as SessionForWriter;
            string mail = writer.WriterMail;
            var Sendlist = _messageService.TListSenderForWriterUser(mail);
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
                var writer = Session["Writer"] as SessionForWriter;
                m.SenderMail = writer.WriterMail;
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