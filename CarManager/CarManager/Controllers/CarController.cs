using CarManager.Context;
using CarManager.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CarManager.Controllers
{
  public class CarController : Controller
  {
    private readonly CarManagerDbContext db = new CarManagerDbContext();

    // GET: Car
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult Create(Car car)
    {
      db.Cars.Add(car);
      db.SaveChanges();
      return View("Index");
    }

    [HttpGet]
    public ActionResult Filter(FilterModel filter)
    {
      List<Car> cars = new List<Car>();

      FilterViewModel vm = new FilterViewModel
      {
        Colors = new List<string>() { "Red", "Blue", "Green" },
        Cars = new List<Car>(),
        //Colors = db.Cars.Select(c => c.Color).Distinct().ToList(),
        //Cars = db.Cars.ToList(),
      };

      return View(vm);
    }
  }
}