using CookieProj.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookieProj.Controllers
{
  public class AnimalController : Controller
  {
    private AnimalContext _db = new AnimalContext();

    public ActionResult Index()
    {
      if (Request.Cookies["animalsAuthKey"] != null)
      {
        var userId = int.Parse(Request.Cookies["animalsAuthKey"].Value);
        return View(_db.Animals.Where(a => a.User.Id == userId));
      }

      return RedirectToAction("Login", "Auth");
    }
  }
}