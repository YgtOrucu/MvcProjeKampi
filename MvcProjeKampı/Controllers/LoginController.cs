using BusinessLayer.Abstract;
using BusinessLayer.Concreate;
using BusinessLayer.Valitadions;
using DataAccessLayer.Context;
using DataAccessLayer.EntityFramawork;
using EntityLayer.Concreate;
using FluentValidation;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampı.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IAdminService _adminService;
        public LoginController()
        {
            _adminService = new AdminManager(new EFAdminDal(), new AdminValidation(),new WriterLoginValidations());
        }
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginSıngIn(Admin admin)
        {
            try
            {
                var result = _adminService.TGetToUserNameAndPassword(admin.UserName, admin.Password);
                if (result.Count != 0)
                {
                    FormsAuthentication.SetAuthCookie(result[0].UserName, false);
                    Session["UserName"] = result[0].UserName;
                    return RedirectToAction("Admin", "Admin");
                }
                else
                {
                    throw new ValidationException("Kullanıcı adı veya şifre hatalı!");
                }
            }
            catch (ValidationException ex)
            {
                if (ex.Errors.Count() != 0)
                {
                    foreach (var error in ex.Errors)
                    {
                        ModelState.AddModelError("", error.ErrorMessage);
                    }
                }
                else
                {
                    ModelState.AddModelError("", ex.Message);
                }
                return View("Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }

        public ActionResult LoginForWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginForWriter(Writer w)
        {
            try
            {
                var result = _adminService.TGetToWriterMailAndPassword(w.WriterMail, w.WriterPassword);
                if (result.Count != 0)
                {
                    FormsAuthentication.SetAuthCookie(result[0].WriterMail, false);
                    Session["WriterMail"] = result[0].WriterMail;
                    Session["WriterID"] = result[0].WriterID.ToString();
                    Session["UserName"] = result[0].WriterName + " " + result[0].WriterSurname;
                    return RedirectToAction("WriterProfile", "WriterPanel");
                }
                else
                {
                    throw new ValidationException("Kullanıcı adı veya şifre hatalı!");
                }
            }
            catch (ValidationException ex)
            {
                if (ex.Errors.Count() != 0)
                {
                    foreach (var error in ex.Errors)
                    {
                        ModelState.AddModelError("", error.ErrorMessage);
                    }
                }
                else
                {
                    ModelState.AddModelError("", ex.Message);
                }
                return View("LoginForWriter");
            }
        }

        public ActionResult LogOutForWriter()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("LoginForWriter", "Login");
        }
    }
}