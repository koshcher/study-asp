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
        private readonly CarService _cs = UnityConfig.Resolver.GetService<CarService>();

        [HttpGet]
        public ActionResult Index()
        {
            var cars = _cs.GetByCondition(c => c.ManagerId == Identity.User.Manager.Id);
            return View(cars);
        }

        [HttpPost]
        public ActionResult Create(Car car)
        {
            car.ManagerId = Identity.User.Manager.Id;
            _cs.Add(car);
            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var car = _cs.GetByCondition(c => c.ManagerId == Identity.User.Manager.Id && c.Id == id).FirstOrDefault();
            return View(car);
        }

        [HttpPost]
        public ActionResult Update(Car car)
        {
            _cs.Update(car);
            return Redirect("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _cs.Delete(id);
            return Redirect("Index");
        }
    }
}