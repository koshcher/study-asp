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

    public ActionResult Index()
    {
      var cars = db.Cars.ToList();
      return View(cars);
    }

    public ActionResult Create(Car car)
    {
      db.Cars.Add(car);
      db.SaveChanges();
      return Redirect("Index");
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
      var car = db.Cars.Find(id);
      return View(car);
    }

    [HttpPost]
    public ActionResult Update(Car car)
    {
      var dbCar = db.Cars.Find(car.Id);
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
      var car = db.Cars.Find(id);
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