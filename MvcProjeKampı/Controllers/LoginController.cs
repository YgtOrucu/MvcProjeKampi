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
            _adminService = new AdminManager(new EFAdminDal(), new AdminValidation(), new WriterLoginValidations());
        }
        // GET: Login
        #region AdminLoginOperation
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
                    if (result[0].AdminStatus)
                    {
                        FormsAuthentication.SetAuthCookie(result[0].UserName, false);
                        Session["UserName"] = result[0].UserName;
                        return RedirectToAction("Admin", "Admin");
                    }
                    else
                    {
                        throw new ValidationException("Kullanıcının sisteme giriş yetkisi yoktur.Pasif Durumdadır.Lütfen Yönertici ile iletişime geçiniz !!");
                    }
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
        #endregion

        #region WriterLoginOperation
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
                    if (result[0].WriterStatus)
                    {
                        FormsAuthentication.SetAuthCookie(result[0].WriterMail, false);
                        var writer = result[0];

                        Session["Writer"] = new SessionForWriter
                        {
                            WriterMail = writer.WriterMail,
                            WriterID = writer.WriterID.ToString(),
                            UserName = $"{writer.WriterName} {writer.WriterSurname}",
                            WriterImage = writer.WriterImage
                        };


                        return RedirectToAction("WriterProfile", "WriterPanel");
                    }
                    else
                    {
                        throw new ValidationException("Kullanıcının sisteme giriş yetkisi yoktur.Pasif Durumdadır.Lütfen Yönertici ile iletişime geçiniz !!");
                    }
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
            Session.Remove("Writer");
            return RedirectToAction("LoginForWriter", "Login");
        }
        #endregion
    }
}