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
using KJFZ.Models.Interfaces;

namespace KJFZ.Controllers
{
    public class UslugaController : Controller
    {
        KJFZRepository kjfzRepository = new KJFZRepository();
        private AutorizacijaClass ac = new AutorizacijaClass();

        // GET: Usluga
        // public IActionResult Index()
        public ActionResult Index()
        {
            if (!ac.Autorizacija(HttpContext, 1))
                return RedirectToAction("NemaOvl", "Home");

            return View(kjfzRepository.UslugaGetAll());
        }

        // GET: Usluga/Details/5
        public IActionResult Details(String? id)
        {
            if (!ac.Autorizacija(HttpContext, 1))
                return RedirectToAction("NemaOvl", "Home");

            if (id == null)
            {
                return NotFound();
            }

            if (!kjfzRepository.UslugaExists(id))
            {
                return NotFound();
            }
            return View(kjfzRepository.UslugaGetById(id));
        }

        // GET: Usluga/Create
        public IActionResult Create()
        {
            if (!ac.Autorizacija(HttpContext, 2))
                return RedirectToAction("NemaOvl", "Home");

            return View();
        }

        // POST: Usluga/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("UslugaId,Cena,Trajanje,Opis,Aktivna")] UslugaBO usluga)
        {
            if (ModelState.IsValid)
            {
                kjfzRepository.UslugaAdd(usluga);
                return RedirectToAction(nameof(Index));
            }
            return View(usluga);
        }

        // GET: Usluga/Edit/5
        public IActionResult Edit(String? id)
        {
            if (!ac.Autorizacija(HttpContext, 2))
                return RedirectToAction("NemaOvl", "Home");

            if (id == null)
            {
                return NotFound();
            }

            if(!kjfzRepository.UslugaExists(id))
            {
                return NotFound();
            }
            return View(kjfzRepository.UslugaGetById(id));
        }

        // POST: Usluga/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(String id, [Bind("UslugaId,Cena,Trajanje,Opis,Aktivna")] UslugaBO usluga)
        {
            if (id != usluga.UslugaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    kjfzRepository.UslugaUpdate(usluga);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!kjfzRepository.UslugaExists(usluga.UslugaId))
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
            return View(usluga);
        }
    }
}
