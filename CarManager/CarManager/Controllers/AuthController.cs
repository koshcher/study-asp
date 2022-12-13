using CarManager.Context;
using CarManager.Models;
using CarManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarManager.Controllers
{
  public class AuthController : Controller
  {
    private CarManagerDbContext _db = new CarManagerDbContext();

    [HttpGet]
    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Login(LoginViewModel data)
    {
      var user = _db.Users.FirstOrDefault(u => u.Email == data.Email && u.Password == data.Password);

      if (user == null)
      {
        ViewBag.Error = "User not found";
        return View();
      }

      Response.Cookies.Add(new HttpCookie("AuthKey", user.Id.ToString()) { Expires = DateTime.Now.AddMinutes(15) });

      return RedirectToAction("Index", "Car");
    }

    [HttpGet]
    public ActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Register(RegisterViewModel data)
    {
      if (data.Password != data.ConfirmPassword)
      {
        ViewBag.Error = "Confirm Password != Password";
        return View();
      }

      var exist = _db.Users.Any(u => u.Email == data.Email);
      if (exist)
      {
        ViewBag.Error = "User exists";
        return View();
      }

      _db.Users.Add(new Models.User() { Email = data.Email, Name = data.Name, Password = data.Password });
      _db.SaveChanges();
      return View("Login");
    }

    [HttpGet]
    public ActionResult Logout()
    {
      Response.Cookies.Add(new HttpCookie("AuthKey", "") { Expires = DateTime.Now.AddMinutes(-15) });
      return RedirectToAction("Filter", "Car");
    }
  }
}