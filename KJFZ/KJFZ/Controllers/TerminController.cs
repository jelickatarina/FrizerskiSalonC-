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
    public class TerminController : Controller
    {
        KJFZRepository kjfzRepository = new KJFZRepository();

        private AutorizacijaClass ac = new AutorizacijaClass();

        private Include1 inc1 = new Include1();

        // GET: Termin
        public IActionResult Index()
        {
            int pNivo = HttpContext.Session.Get<int>("Nivo");
            if (pNivo == 1)
            {
                string pKorisnikId = HttpContext.Session.Get<String>("KorisnikId");
                return View(kjfzRepository.TerminGetForKlijent(pKorisnikId));
            }
            else if (pNivo == 2)
            {
                string pKorisnikId = HttpContext.Session.Get<String>("KorisnikId");
                return View(kjfzRepository.TerminGetForFrizer(pKorisnikId));
            }
            else
            { 
                return View(kjfzRepository.TerminGetAll());
            }
        }

        // GET: Termin/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (!kjfzRepository.TerminExists(id))
            {
                return NotFound();
            }

            return View(kjfzRepository.TerminGetById(id));
        }

        // GET: Termin/Create
        public IActionResult Create()
        {
            ViewData["T1"] = 1;
            ViewData["KorisnikFrizerId"] = new SelectList(kjfzRepository.KorisnikGetFrizer(), "KorisnikId", "KorisnikId");
            ViewData["UslugaId"] = new SelectList(kjfzRepository.UslugaGetAktivna(), "UslugaId", "UslugaId");
            return View();
        }

        // POST: Termin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("TerminId,UslugaId,KorisnikId,Datum,Vreme,Uradjeno,KorisnikFrizerId")] TerminBO termin, 
            int T1, string VremeHalfHour)
        {
            if (T1 == 1)
            {
                DateOnly d1 = DateOnly.Parse(termin.Datum.ToString());
                if (d1.CompareTo(DateOnly.FromDateTime(DateTime.Now)) < 0)
                {
                    ViewData["T1"] = 1;
                    ViewData["KorisnikFrizerId"] = new SelectList(kjfzRepository.KorisnikGetFrizer(), "KorisnikId", "KorisnikId");
                    ViewData["UslugaId"] = new SelectList(kjfzRepository.UslugaGetAktivna(), "UslugaId", "UslugaId");
                    ViewData["Error"] = "Datum je u prošlosti";
                    return View();
                }
                else if (d1.CompareTo(DateOnly.FromDateTime(DateTime.Now.AddDays(7))) > 0)
                {
                    ViewData["T1"] = 1;
                    ViewData["KorisnikFrizerId"] = new SelectList(kjfzRepository.KorisnikGetFrizer(), "KorisnikId", "KorisnikId");
                    ViewData["UslugaId"] = new SelectList(kjfzRepository.UslugaGetAktivna(), "UslugaId", "UslugaId");
                    ViewData["Error"] = "Zakazivanje se vrši maksimalno 7 dana unapred";
                    return View();
                }
                else if (d1.DayOfWeek == DayOfWeek.Sunday)
                {
                    ViewData["T1"] = 1;
                    ViewData["KorisnikFrizerId"] = new SelectList(kjfzRepository.KorisnikGetFrizer(), "KorisnikId", "KorisnikId");
                    ViewData["UslugaId"] = new SelectList(kjfzRepository.UslugaGetAktivna(), "UslugaId", "UslugaId");
                    ViewData["Error"] = "Ne radimo nedeljom";
                    return View();
                }

                UslugaBO usluga1  = kjfzRepository.UslugaGetById(termin.UslugaId);
                int ukupnoTermina = 1+(usluga1.Trajanje-1)/30; //Koliko termina zauzima usluga

                // ZAUZETI TERMINI
                List<int> zauzetiTermini = new List<int>();
                var c2 = kjfzRepository.TerminGetZauzeti(termin.KorisnikFrizerId, d1);
                foreach (var e1 in c2)
                {
                    int ztr = e1.Vreme;
                    zauzetiTermini.Add(ztr);

                    var usluga2 = kjfzRepository.UslugaGetById(e1.UslugaId);
                    int trajanjeTermina = 1 + (usluga2.Trajanje-1) / 30;
                    for(int i=1;i<trajanjeTermina;i++)
                    {
                        ztr++;
                        zauzetiTermini.Add(ztr);
                    }
                }

                List<string> av = new List<string>();
                bool nemoze;
                for (int i = 18; i <= (34 - ukupnoTermina); i++)
                {
                    nemoze = false;
                    if(zauzetiTermini.IndexOf(i)<0)
                    {
                        for(int j=1; j<ukupnoTermina; j++)
                        {
                            if (zauzetiTermini.IndexOf(i + j) >= 0) nemoze = true;
                        }
                        if (!nemoze) av.Add(inc1.intToHalfHour(i.ToString()));
                    }
                }

                if(av.Count==0)
                {
                    ViewData["T1"] = 1;
                    ViewData["KorisnikFrizerId"] = new SelectList(kjfzRepository.KorisnikGetFrizer(), "KorisnikId", "KorisnikId");
                    ViewData["UslugaId"] = new SelectList(kjfzRepository.UslugaGetAktivna(), "UslugaId", "UslugaId");
                    ViewData["Error"] = "Nema slobodnih termina";
                    return View();
                }

                ViewData["T1"] = 2;
                ViewData["VremeHalfHour"] = new SelectList(av);
                return View();
            } // T1==1
            else
            {
                termin.Vreme = inc1.HalfHourToInt(VremeHalfHour); 
                kjfzRepository.TerminAdd(termin);
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Termin/Edit/5
        public IActionResult Edit(int? id)
        {
            if (!ac.Autorizacija(HttpContext, 2))
                return RedirectToAction("NemaOvl", "Home");

            if (!kjfzRepository.TerminExists(id))
            {
                return NotFound();
            }

            TerminBO termin = kjfzRepository.TerminGetById(id);
            ViewData["VremeHalfHour"] = inc1.intToHalfHour(termin.Vreme.ToString());
            return View(termin);
        }

        // POST: Termin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("TerminId,UslugaId,KorisnikId,Datum,Vreme,Uradjeno,KorisnikFrizerId")] TerminBO termin)
        {
            if (id != termin.TerminId)
            {
                return NotFound();
            }
                try
                {
                    kjfzRepository.TerminUpdate(termin);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!kjfzRepository.TerminExists(termin.TerminId))
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

        // GET: Termin/Delete
        public IActionResult Delete(int? id) 
        {
            if (id == null)
            {
                return NotFound();
            }

            if (!kjfzRepository.TerminExists(id))
            {
                return NotFound();
            }

            return View(kjfzRepository.TerminGetById(id));
        }

        // POST: Termin/Delete
        [HttpPost, ActionName("Delete")] //Otkazivanje termina
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (kjfzRepository.TerminExists(id))
            {
                kjfzRepository.TerminDelete(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
