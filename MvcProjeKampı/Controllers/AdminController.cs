using BusinessLayer.Abstract;
using BusinessLayer.Concreate;
using BusinessLayer.Valitadions;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.EntityFramawork;
using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampı.Controllers
{
    public class AdminController : Controller
    {
        #region ConstructorMethods
        MvcKampContext context = new MvcKampContext();
        private readonly ICategoryService _categoryService;
        private readonly IWriterService _writerService;
        private readonly IHeadingService _headingService;
        private readonly IContentService _contentService;
        private readonly IAboutService _aboutService;
        private readonly IContactService _contactService;
        private readonly IMessageService _messageService;
        private readonly IAdminService _adminService;

        public AdminController()
        {
            _categoryService = new CategoryManager(new EFCategoryDal(), new CategoryValitadions());
            _writerService = new WriterManager(new EFWriterDal(), new WriterValitadion());
            _headingService = new HeadingManager(new EFHeadingDal(), new HeadingValidation());
            _contentService = new ContentManager(new EFContentDal());
            _aboutService = new AboutManager(new EFAboutDal(), new AboutValidation());
            _contactService = new ContactManager(new EFContactDal());
            _messageService = new MessageManager(new EFMessageDal(), new MessageValidation());
            _adminService = new AdminManager(new EFAdminDal(), new AdminValidation(), new WriterLoginValidations());
        }
        #endregion

        #region ErrorPages
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
        public ActionResult WritersHeading(int id)
        {
            var getWritersHeading = _headingService.TGetListByWriter(id);
            return View("WritersHeading", getWritersHeading);
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

        [HttpGet]
        public ActionResult HeadingEdit(int id)
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

            var getHeading = _headingService.TGetID(id);
            return View("HeadingEdit", getHeading);
        }

        [HttpPost]
        public ActionResult HeadingUpdate(Heading h)
        {
            var updatedheading = _headingService.TGetID(h.HeadingID);
            updatedheading.HeadingName = h.HeadingName;
            updatedheading.HeadingDate = h.HeadingDate;
            updatedheading.CategoryID = h.CategoryID;
            updatedheading.WriterID = h.WriterID;
            updatedheading.HeadingStatus = h.HeadingStatus;
            _headingService.TUpdate(updatedheading);
            return RedirectToAction("Heading");
        }
        #endregion

        #region ContentOperations
        public ActionResult ContentByHeading(int id)
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
                TempData["RedirectToAction"] = "Writer";
                return View("ErrorPages");
            }
        }
        #endregion

        #region AboutOperation
        public ActionResult About()
        {
            var values = _aboutService.TGetList();
            return View(values);
        }
        [HttpPost]
        public ActionResult AboutAdd(About a)
        {
            try
            {
                _aboutService.TInsert(a);
                return RedirectToAction("About");
            }
            catch (ValidationException ex)
            {
                var errormessage = string.Join("<br>", ex.Errors.Select(x => x.ErrorMessage));
                TempData["ValidationErrors"] = errormessage;
                TempData["RedirectToAction"] = "About";
                return RedirectToAction("ErrorPages");
            }
        }
        [HttpGet]
        public ActionResult AboutEdit(int id)
        {
            var getAbout = _aboutService.TGetID(id);
            return View("AboutEdit", getAbout);
        }
        [HttpPost]
        public ActionResult AboutUpdate(About a)
        {
            try
            {
                var updatedAbout = _aboutService.TGetID(a.AboutID);
                updatedAbout.AboutDetails1 = a.AboutDetails1;
                updatedAbout.AboutDetails2 = a.AboutDetails2;
                updatedAbout.AboutImage1 = a.AboutImage1;
                updatedAbout.AboutImage2 = a.AboutImage2;
                updatedAbout.AboutStatus = a.AboutStatus;
                _aboutService.TUpdate(updatedAbout);
                return RedirectToAction("About");
            }
            catch (ValidationException ex)
            {
                var errormessage = string.Join("<br>", ex.Errors.Select(x => x.ErrorMessage));
                TempData["ValidationErrors"] = errormessage;
                TempData["RedirectToAction"] = "About";
                return RedirectToAction("ErrorPages");
            }
        }
        #endregion

        #region ContactandMessageOperation

        public void InboxAndSentForAdminMessageCount()
        {
            int getInboxMessageCount = _messageService.TTotalNumberOfInbox();
            int getSendMessageCount = _messageService.TTotalNumberOfSent();
            int getUserMessageCount = _contactService.TTotalNumberOfUserMessage();
            ViewBag.ınboxcount = getInboxMessageCount;
            ViewBag.sentcount = getSendMessageCount;
            ViewBag.UserMessageCount = getUserMessageCount;
        }

        public ActionResult Contact()
        {
            var Contact = _contactService.TGetListToStatus();
            return View(Contact);
        }
        public ActionResult ContactDelete(int id)
        {
            var getdeletedvalue = _contactService.TGetID(id);
            getdeletedvalue.ContactStatus = false;
            getdeletedvalue.ContactDate = DateTime.Now;
            _contactService.TUpdate(getdeletedvalue);
            return RedirectToAction("Contact");
        }
        public ActionResult ContactDeletedPage()
        {
            var values = context.Contacts.Where(x => x.ContactStatus == false).ToList();
            return View(values);
        }
        public ActionResult ContactDetails(int id)
        {
            if (User.IsInRole("Admin Yardımcısı")) { return RedirectToAction("AuthorizationErrorPage", "ErrorPage"); }
            var getcontactdetails = _contactService.TGetID(id);
            return View(getcontactdetails);
        }
        public ActionResult ContactandMessage()
        {
            var Inboxlist = _messageService.TListInboxForAdminUser();
            return View(Inboxlist);
        }
        public ActionResult SendBoxForAdmin()
        {
            var Sendlist = _messageService.TListSenderForAdminUser();
            return View(Sendlist);
        }
        public ActionResult ContactandMessageDetails(int id)
        {
            if (User.IsInRole("Admin Yardımcısı")) { return RedirectToAction("AuthorizationErrorPage", "ErrorPage"); }
            var getmessagedetails = _messageService.TGetID(id);
            return View(getmessagedetails);
        }
        public PartialViewResult LeftBarArea()
        {
            InboxAndSentForAdminMessageCount();
            return PartialView();
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
                m.SenderMail = "admin@gmail.com";
                m.MessageDate = DateTime.Now;
                _messageService.TInsert(m);
                return RedirectToAction("SendBoxForAdmin");

            }
            catch (ValidationException ex)
            {
                var errormessage = string.Join("<br>", ex.Errors.Select(x => x.ErrorMessage));
                TempData["ValidationErrors"] = errormessage;
                TempData["RedirectToAction"] = "NewMessage";
                return RedirectToAction("ErrorPages");
            }
        }

        #region SearchSendMailToSendPage
        [HttpPost]
        public ActionResult SearchSendMail(string p)
        {
            var query = context.Messages.AsQueryable();

            if (!string.IsNullOrEmpty(p))
            {
                query = query.Where(x => x.ReceiverMail.Contains(p) && x.SenderMail == "admin@gmail.com");
                var values = query.ToList();
                return View(values);
            }
            else
            {
                return RedirectToAction("SendBoxForAdmin");
            }
        }

        #endregion

        #region SearchInboxMailToInboxPage
        public ActionResult SearchInboxMail(string p)
        {
            var query = context.Messages.AsQueryable();

            if (!string.IsNullOrEmpty(p))
            {
                query = query.Where(x => x.ReceiverMail == "admin@gmail.com" && x.SenderMail.Contains(p));
                var values = query.ToList();
                return View(values);
            }
            else
            {
                return RedirectToAction("ContactandMessage");
            }
        }
        #endregion

        #region SearchTrashMailNameToDeletePage
        [HttpPost]
        public ActionResult SearchTrashMail(string p)
        {
            var query = context.Contacts.AsQueryable();

            if (!string.IsNullOrEmpty(p))
            {
                query = query.Where(x => x.ContactStatus == false && x.UserName.Contains(p));
                var values = query.ToList();
                return View(values);
            }
            else
            {
                return RedirectToAction("ContactDeletedPage");
            }
        }

        #endregion


        #endregion

        #region GalleryOperations
        public ActionResult Gallery()
        {
            var values = context.ImagesFiles.ToList();
            return View(values);
        }
        #endregion

        #region AdminOperations

        public ActionResult Admin()
        {
            #region GetRoleTypeNameandId
            var getroletype = context.Roles.Take(2).Select(x => new SelectListItem
            {
                Value = x.RoleID.ToString(),
                Text = x.RoleType
            }).ToList();
            ViewBag.RoleType = getroletype;
            #endregion

            if (User.IsInRole("Admin Yardımcısı")) { return RedirectToAction("AuthorizationErrorPage", "ErrorPage"); }
            var values = _adminService.TGetList();
            return View(values);
        }

        [HttpPost]
        public ActionResult AdminAdd(Admin a)
        {
            try
            {
                _adminService.TInsert(a);
                return RedirectToAction("Admin");
            }
            catch (ValidationException ex)
            {
                var errormessage = string.Join("<br>", ex.Errors.Select(x => x.ErrorMessage));
                TempData["ValidationErrors"] = errormessage;
                TempData["RedirectToAction"] = "Admin";
                return RedirectToAction("ErrorPages");
            }
        }

        [HttpGet]
        public ActionResult AdminEdit(int id)
        {
            #region GetRoleTypeNameandId
            var values = context.Roles.Take(2).Select(x => new SelectListItem
            {
                Value = x.RoleID.ToString(),
                Text = x.RoleType
            }).ToList();
            ViewBag.RoleType = values;
            #endregion
            var getAdmin = _adminService.TGetID(id);
            return View("AdminEdit", getAdmin);
        }

        [HttpPost]
        public ActionResult AdminUpdate(Admin a)
        {
            try
            {
                var updatedAdmin = _adminService.TGetID(a.AdminID);
                updatedAdmin.UserName = a.UserName;
                updatedAdmin.Password = a.Password;
                updatedAdmin.RoleID = a.RoleID;
                updatedAdmin.AdminStatus = a.AdminStatus;
                _adminService.TUpdate(updatedAdmin);
                return RedirectToAction("Admin");
            }
            catch (ValidationException ex)
            {
                var errormessage = string.Join("<br>", ex.Errors.Select(x => x.ErrorMessage));
                TempData["ValidationErrors"] = errormessage;
                TempData["RedirectToAction"] = "Admin";
                return RedirectToAction("ErrorPages");
            }
        }
        #endregion
    }
}