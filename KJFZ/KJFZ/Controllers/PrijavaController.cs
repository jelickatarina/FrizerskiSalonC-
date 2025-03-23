using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KJFZ.Data;
using KJFZ.Models;
using KJFZ.Models.EFRepository;

namespace KJFZ.Controllers
{
    public class PrijavaController : Controller
    {
        KJFZRepository kjfzRepository = new KJFZRepository();

        // GET: Prijava/Index
        public IActionResult Index()
        {
            HttpContext.Session.Set<String>("KorisnikId", "");
            HttpContext.Session.Set<int>("Nivo", 0);
            return View();
        }

        // POST: Prijava/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string pKorisnikId, string pLozinka)
        {
            if (kjfzRepository.KorisnikPrijava(pKorisnikId, pLozinka))
            {
                HttpContext.Session.Set<String>("KorisnikId", pKorisnikId);
                HttpContext.Session.Set<int>("Nivo", kjfzRepository.KorisnikNivo(pKorisnikId));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Failed login, return to the login page with an error message
                ViewBag.Error = "NEISPRAVNI PODACI";
                return View();
            }
        }
    }
}
