using CarManager.Context;
using CarManager.Filters;
using CarManager.Helper;
using CarManager.Models;
using System.Linq;
using System.Web.Mvc;

namespace CarManager.Controllers
{
  [AuthActionFilter]
  public class ManageController : Controller
  {
    private readonly CarManagerDbContext _db;

    public ManageController()
    {
      _db = UnityConfig.Resolver.GetService<CarManagerDbContext>();
    }

    [HttpGet]
    public ActionResult Index()
    {
      var cars = _db.Cars.Where(c => c.User.Id == Identity.User.Id).ToList();
      return View(cars);
    }

    [HttpPost]
    public ActionResult Create(Car car)
    {
      car.UserId = Identity.User.Id;
      _db.Cars.Add(car);
      _db.SaveChanges();
      return Redirect("Index");
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
      //int? userId = UserId();
      //if (userId == null) return RedirectToAction("Login", "Auth");

      var car = _db.Cars.First(c => c.User.Id == Identity.User.Id && c.Id == id);
      return View(car);
    }

    [HttpPost]
    public ActionResult Update(Car car)
    {
      //int? userId = UserId();
      //if (userId == null) return RedirectToAction("Login", "Auth");

      var dbCar = _db.Cars.First(c => c.User.Id == Identity.User.Id && c.Id == car.Id);
      dbCar.Num = car.Num;
      dbCar.Name = car.Name;
      dbCar.Year = car.Year;
      dbCar.Secondhand = car.Secondhand;
      dbCar.Color = car.Color;
      dbCar.Model = car.Model;
      _db.SaveChanges();
      return Redirect("Index");
    }

    [HttpDelete]
    public ActionResult Delete(int id)
    {
      //int? userId = UserId();
      //if (userId == null) return RedirectToAction("Login", "Auth");

      var car = _db.Cars.First(c => c.User.Id == Identity.User.Id && c.Id == id);
      _db.Cars.Remove(car);
      _db.SaveChanges();
      return Redirect("Index");
    }
  }
}