using CarManager.Context.Models;
using CarManager.Filters;
using CarManager.Helper;
using CarManager.Services;
using System.Linq;
using System.Web.Mvc;

namespace CarManager.Controllers
{
    [AuthFilter]
    [ManagerFilter]
    public class ManageController : Controller
    {
        private readonly CarService _cars = UnityConfig.Resolver.GetService<CarService>();

        [HttpPost]
        public ActionResult Create(Car car)
        {
            _cars.Add(car);
            return Redirect("Index");
        }

        public ActionResult Delete(int id)
        {
            _cars.Delete(id);
            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var car = _cars.GetByCondition(c => c.ManagerId == Identity.User.Manager.Id && c.Id == id).FirstOrDefault();
            return View(car);
        }

        [HttpGet]
        public ActionResult Index()
        {
            var cars = _cars.GetByCondition(c => c.ManagerId == Identity.User.Manager.Id);
            return View(cars);
        }

        [HttpPost]
        public ActionResult Update(Car car)
        {
            _cars.Update(car);
            return Redirect("Index");
        }
    }
}