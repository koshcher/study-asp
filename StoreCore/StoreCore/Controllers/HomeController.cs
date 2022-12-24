using Microsoft.AspNetCore.Mvc;
using StoreCore.Context;
using StoreCore.Models;
using System.Diagnostics;

namespace StoreCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StoreContext _db;

        public HomeController(ILogger<HomeController> logger, StoreContext db)
        {
            _db= db;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}