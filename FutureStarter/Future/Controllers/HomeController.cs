using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Future.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      var product = new
      {
        name = "Item 1",
        price = 2000,
        description = "Desc"
      };
      return Json(product, JsonRequestBehavior.AllowGet);
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}