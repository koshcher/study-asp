using System.Web.Mvc;

namespace Future.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult DownloadBytes()
    {
      var path = Server.MapPath("/Content/me.png");
      var bytes = System.IO.File.ReadAllBytes(path);
      return File(bytes, "image/png");
    }

    public ActionResult DownloadStream()
    {
      var path = Server.MapPath("/Content/me.zip");

      return File(System.IO.File.OpenRead(path), "application/zip");
    }
  }
}