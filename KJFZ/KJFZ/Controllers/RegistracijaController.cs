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
    public class RegistracijaController : Controller
    {

        KJFZRepository kjfzRepository = new KJFZRepository();

        // GET: Prijava/Create
        public IActionResult Index()
        {
            return View();
        }

        // POST: Prijava/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind("KorisnikId,Lozinka,Ime,Prezime,Kontakt,DatumRodjenja,Telefon,Email,Nivo")] KorisnikBO korisnik)
        {
            if (ModelState.IsValid)
            {
                kjfzRepository.KorisnikAdd(korisnik);
                HttpContext.Session.Set<String>("KorisnikId", korisnik.KorisnikId);
                HttpContext.Session.Set<int>("Nivo", korisnik.Nivo);

                return RedirectToAction("Index","Home");
            }
            return View(korisnik);
        }
    }
}
