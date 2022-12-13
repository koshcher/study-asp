using CarManager.Context;
using CarManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;

namespace CarManager.Controllers
{
  public class CarController : Controller
  {
    private readonly CarManagerDbContext db = new CarManagerDbContext();

    private int? UserId()
    {
      if (Request.Cookies["AuthKey"] == null) return null;
      return int.Parse(Request.Cookies["AuthKey"].Value);
    }

    public ActionResult Index()
    {
      int? userId = UserId();
      if (userId == null) return RedirectToAction("Login", "Auth");

      var cars = db.Cars.Where(c => c.User.Id == userId).ToList();
      return View(cars);
    }

    public ActionResult Create(Car car)
    {
      int? userId = UserId();
      if (userId == null) return RedirectToAction("Login", "Auth");

      car.User = db.Users.Find(userId);

      db.Cars.Add(car);
      db.SaveChanges();
      return Redirect("Index");
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
      int? userId = UserId();
      if (userId == null) return RedirectToAction("Login", "Auth");

      var car = db.Cars.First(c => c.User.Id == userId && c.Id == id);
      return View(car);
    }

    [HttpPost]
    public ActionResult Update(Car car)
    {
      int? userId = UserId();
      if (userId == null) return RedirectToAction("Login", "Auth");

      var dbCar = db.Cars.First(c => c.User.Id == userId && c.Id == car.Id);
      dbCar.Num = car.Num;
      dbCar.Name = car.Name;
      dbCar.Year = car.Year;
      dbCar.Secondhand = car.Secondhand;
      dbCar.Color = car.Color;
      dbCar.Model = car.Model;
      db.SaveChanges();
      return Redirect("Index");
    }

    public ActionResult Delete(int id)
    {
      int? userId = UserId();
      if (userId == null) return RedirectToAction("Login", "Auth");

      var car = db.Cars.First(c => c.User.Id == userId && c.Id == id);
      db.Cars.Remove(car);
      db.SaveChanges();
      return Redirect("Index");
    }

    [HttpGet]
    public ActionResult Filter(FilterModel filter)
    {
      IQueryable<Car> cars = db.Cars;

      if (filter.State == SecondhandState.New)
      {
        cars = cars.Where(c => c.Secondhand == false);
      }
      else if (filter.State == SecondhandState.Secondhand)
      {
        cars = cars.Where(c => c.Secondhand == true);
      }

      if (!filter.Name.IsEmpty()) cars = cars.Where(c => c.Name.StartsWith(filter.Name));
      if (!filter.Model.IsEmpty()) cars = cars.Where(c => c.Model.StartsWith(filter.Model));
      if (!filter.Color.IsEmpty()) cars = cars.Where(c => c.Color.StartsWith(filter.Color));
      if (filter.Num != null) cars = cars.Where(c => c.Num == filter.Num);
      if (filter.Year != null) cars = cars.Where(c => c.Year == filter.Year);

      FilterViewModel vm = new FilterViewModel
      {
        Colors = db.Cars.Select(c => c.Color).Distinct().ToList(),
        Cars = cars.ToList(),
      };

      return View(vm);
    }
  }
}