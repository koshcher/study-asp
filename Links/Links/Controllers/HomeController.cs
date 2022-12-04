using System.Web.Mvc;

namespace Links.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Home()
    {
      return View();
    }

    public ActionResult Products()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }

    public ActionResult Services()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }
  }
}