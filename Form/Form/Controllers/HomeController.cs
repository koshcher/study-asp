using Form.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Form.Controllers
{
  public class HomeController : Controller
  {
    private List<Product> products;

    public HomeController()
    {
      products = new List<Product>()
      {
        new Product() { Id = 1, Name = "Milk", Price=20 },
        new Product() { Id = 2, Name = "Bear", Price=40 },
        new Product() { Id = 3, Name = "Cvas", Price=30 },
        new Product() { Id = 4, Name = "Vodka", Price=100 },
      };
    }

    public ActionResult Index()
    {
      return View(products);
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