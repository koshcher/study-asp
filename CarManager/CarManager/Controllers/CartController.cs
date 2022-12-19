using CarManager.Filters;
using CarManager.Services;
using System.Web.Mvc;

namespace CarManager.Controllers
{
    [AuthFilter]
    public class CartController : Controller
    {
        private readonly CartService _cart = UnityConfig.Resolver.GetService<CartService>();

        public ActionResult Index()
        {
            return View(_cart.List());
        }

        public ActionResult Add(int id, string redirect)
        {
            _cart.Add(id);
            return Redirect(redirect);
        }

        public ActionResult Remove(int id, string redirect)
        {
            _cart.Remove(id);
            return Redirect(redirect);
        }
    }
}