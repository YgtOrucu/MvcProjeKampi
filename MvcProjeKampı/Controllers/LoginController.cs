using BusinessLayer.Abstract;
using BusinessLayer.Concreate;
using BusinessLayer.Valitadions;
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
            _adminService = new AdminManager(new EFAdminDal(), new AdminValidation());
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
                    FormsAuthentication.SetAuthCookie(admin.UserName, false);
                    Session["UserName"] = admin.UserName;
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
    }
}