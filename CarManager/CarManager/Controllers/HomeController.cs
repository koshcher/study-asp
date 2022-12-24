using CarManager.Models;
using CarManager.Services;
using System.Linq;
using System.Web.Mvc;

namespace CarManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly CarService _cars = UnityConfig.Resolver.GetService<CarService>();

        [HttpGet]
        public ActionResult Index(FilterModel filter)
        {
            var cars = _cars.Filter(filter);

            FilterViewModel vm = new FilterViewModel
            {
                Colors = cars.Select(c => c.Color).Distinct().ToList(),
                Cars = cars
            };

            return View(vm);
        }
    }
}