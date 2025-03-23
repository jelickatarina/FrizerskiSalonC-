using System.Diagnostics;
using KJFZ.Models;
using Microsoft.AspNetCore.Mvc;

namespace KJFZ.Controllers
{
    public class HomeController : Controller
    {
        AutorizacijaClass ac = new AutorizacijaClass();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ONama()
        {
            return View();
        }

        public IActionResult NemaOvl()
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
