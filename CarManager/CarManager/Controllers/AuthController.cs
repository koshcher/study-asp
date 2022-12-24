using CarManager.Context.Models;
using CarManager.Helper;
using CarManager.Models.ViewModels;
using CarManager.Services;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace CarManager.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService _auth = UnityConfig.Resolver.GetService<AuthService>();

        [HttpGet]
        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult Login(LoginViewModel data)
        {
            var user = _auth.Login(data.Email, data.Password);

            if (user == null)
            {
                ViewBag.Error = "User not found";
                return View();
            }

            Response.Cookies.Add(new HttpCookie("AuthKey", user.Id.ToString()) { Expires = DateTime.Now.AddMinutes(15) });
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register() => View();

        [HttpPost]
        public ActionResult Register(RegisterViewModel data)
        {
            if (data.Email.IsEmpty() || data.Password.IsEmpty())
            {
                ViewBag.Error = "Email and password can't be empty";
                return View();
            }
            if (data.Password != data.ConfirmPassword)
            {
                ViewBag.Error = "Confirm Password != Password";
                return View();
            }

            var user = _auth.Register(new User { Name = data.Name, Email = data.Email, Password = data.Password }, data.IsManager);
            if (user == null)
            {
                ViewBag.Error = "Email is taken";
                return View();
            }
            return View("Login");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Response.Cookies.Add(new HttpCookie("AuthKey", "") { Expires = DateTime.Now.AddMinutes(-15) });
            Identity.User = null;
            return RedirectToAction("Index", "Home");
        }
    }
}