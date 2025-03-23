using Microsoft.AspNetCore.Mvc;

namespace KJFZ.Controllers
{
    public class OdjavaController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.Set<String>("KorisnikId", "");
            HttpContext.Session.Set<int>("Nivo", 0);
            return View();
        }
    }
}
