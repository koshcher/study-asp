using CarManager.Models;
using CarManager.Services;
using System.Linq;
using System.Web.Mvc;

namespace CarManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly CarService _cs = UnityConfig.Resolver.GetService<CarService>();
        private readonly CartService _cart = UnityConfig.Resolver.GetService<CartService>();

        [HttpGet]
        public ActionResult Index(FilterModel filter)
        {
            var cars = _cs.Filter(filter);

            FilterViewModel vm = new FilterViewModel
            {
                Colors = cars.Select(c => c.Color).Distinct().ToList(),
                Cars = cars
            };

            return View(vm);
        }
    }
}