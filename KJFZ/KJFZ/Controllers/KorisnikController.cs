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
    public class KorisnikController : Controller
    {
        private AutorizacijaClass ac = new AutorizacijaClass();

        KJFZRepository kjfzRepository = new KJFZRepository();

        // GET: Korisnik
        public IActionResult Index() //Vraca pogled sa svim korisnicima 
        {
            if (!ac.Autorizacija(HttpContext, 9))
                return RedirectToAction("NemaOvl", "Home");
            else
                return View(kjfzRepository.KorisnikGetAll());
        }

        // GET: Korisnik/Details/5
        public IActionResult Details(string id) //Vraca pogled za detalje o korisniku
        {
            if (!ac.Autorizacija(HttpContext, 9))
                return RedirectToAction("NemaOvl", "Home");

            if (id == null)
            {
                return NotFound();
            }

            if (!kjfzRepository.KorisnikExists(id))
            {
                return NotFound();
            }
            return View(kjfzRepository.KorisnikGetById(id));
        }

        // GET: Korisnik/Create
        public IActionResult Create() //Vraca pogled za dodavanje korisnika
        {
            if (!ac.Autorizacija(HttpContext, 9))
                return RedirectToAction("NemaOvl", "Home");

            return View();
        }

        // POST: Korisnik/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("KorisnikId,Lozinka,Ime,Prezime,Kontakt,DatumRodjenja,Telefon,Email,Nivo")] KorisnikBO korisnik80)
        {
            if (ModelState.IsValid)
            {
                kjfzRepository.KorisnikAdd(korisnik80);
                return RedirectToAction(nameof(Index));
            }
            return View(korisnik80);
        }

        // GET: Korisnik/Edit/5
        public IActionResult Edit(string id)
        {
            if (!ac.Autorizacija(HttpContext, 9))
                return RedirectToAction("NemaOvl", "Home");

            if (id == null)
            {
                return NotFound();
            }

            if (!kjfzRepository.KorisnikExists(id))
            {
                return NotFound();
            }
            return View(kjfzRepository.KorisnikGetById(id));
        }

        // POST: Korisnik/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("KorisnikId,Lozinka,Ime,Prezime,Kontakt,DatumRodjenja,Telefon,Email,Nivo")] KorisnikBO korisnik)
        {
            if (id != korisnik.KorisnikId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    kjfzRepository.KorisnikUpdate(korisnik);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!kjfzRepository.KorisnikExists(korisnik.KorisnikId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(korisnik);
        }
    }
}
