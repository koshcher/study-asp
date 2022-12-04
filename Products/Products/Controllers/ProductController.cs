using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Products.Controllers
{
  public class ProductController : Controller
  {
    private List<Product> products;

    // GET: Product
    public ActionResult Index()
    {
      products = new List<Product>()
      {
        new Product{ ID = Guid.NewGuid(), CreatedDate= DateTime.Now, Name = "APPLE", Price=10 },
        new Product{ ID = Guid.NewGuid(), CreatedDate= DateTime.Now, Name = "CHARGER", Price=120 },
        new Product{ ID = Guid.NewGuid(), CreatedDate= DateTime.Now, Name = "LAPTOP", Price=25000 },
        new Product{ ID = Guid.NewGuid(), CreatedDate= DateTime.Now, Name = "DISK", Price=520 },
      };

      return View(products);
    }
  }
}