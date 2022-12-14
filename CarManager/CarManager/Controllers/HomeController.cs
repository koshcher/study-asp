using CarManager.Context;
using CarManager.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;

namespace CarManager.Controllers
{
  public class HomeController : Controller
  {
    private readonly CarManagerDbContext _db;

    public HomeController()
    {
      _db = UnityConfig.Resolver.GetService<CarManagerDbContext>();
    }

    [HttpGet]
    public ActionResult Index(FilterModel filter)
    {
      IQueryable<Car> cars = _db.Cars;

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
        Colors = _db.Cars.Select(c => c.Color).Distinct().ToList(),
        Cars = cars.ToList(),
      };

      return View(vm);
    }
  }
}