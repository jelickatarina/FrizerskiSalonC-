using KJFZ.Data;
using KJFZ.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KJFZ.Models.EFRepository
{
    public class KJFZRepository
    {
        private KJFZContext kjfzEntities = new KJFZContext();

        #region Methods
        #region Korisnik
        public IEnumerable<KorisnikBO> KorisnikGetAll() //Uzima sve korisnike 
        {
            List<KorisnikBO> korisnici = new List<KorisnikBO>();

            foreach (Korisnik korisnik in kjfzEntities.Korisnik)
            {
                korisnici.Add(new KorisnikBO
                {
                    KorisnikId = korisnik.KorisnikId,
                    Lozinka = korisnik.Lozinka,
                    Ime = korisnik.Ime,
                    Prezime = korisnik.Prezime,
                    DatumRodjenja = korisnik.DatumRodjenja,
                    Telefon = korisnik.Telefon,
                    Email = korisnik.Email,
                    Nivo = korisnik.Nivo
                });
            }
            return korisnici;
        }

        public KorisnikBO KorisnikGetById(string id) //Uzima korisnika po id-ju
        {
            KorisnikBO korisnikBO = new KorisnikBO();
            var korisnik = kjfzEntities.Korisnik.First(m => m.KorisnikId == id);
            if (korisnik != null)
            {
                korisnikBO.KorisnikId = korisnik.KorisnikId;
                korisnikBO.Lozinka = korisnik.Lozinka;
                korisnikBO.Ime = korisnik.Ime;
                korisnikBO.Prezime = korisnik.Prezime;
                korisnikBO.DatumRodjenja = korisnik.DatumRodjenja;
                korisnikBO.Telefon = korisnik.Telefon;
                korisnikBO.Email = korisnik.Email;
                korisnikBO.Nivo = korisnik.Nivo;
            }
            return korisnikBO;
        }

        public void KorisnikAdd(KorisnikBO korisnikBO) //Dodavanje korisnika
        {
            Korisnik korisnik = new Korisnik();
            korisnik.KorisnikId = korisnikBO.KorisnikId;
            korisnik.Lozinka = korisnikBO.Lozinka;
            korisnik.Ime = korisnikBO.Ime;
            korisnik.Prezime = korisnikBO.Prezime;
            korisnik.DatumRodjenja = korisnikBO.DatumRodjenja;
            korisnik.Telefon = korisnikBO.Telefon;
            korisnik.Email = korisnikBO.Email;
            korisnik.Nivo = korisnikBO.Nivo;
            kjfzEntities.Korisnik.Add(korisnik);
            kjfzEntities.SaveChanges();
        }

        public void KorisnikUpdate(KorisnikBO korisnikBO) //Azuriranje korisnika
        {
            Korisnik korisnik = new Korisnik();
            korisnik.KorisnikId = korisnikBO.KorisnikId;
            korisnik.Lozinka = korisnikBO.Lozinka;
            korisnik.Ime = korisnikBO.Ime;
            korisnik.Prezime = korisnikBO.Prezime;
            korisnik.DatumRodjenja = korisnikBO.DatumRodjenja;
            korisnik.Telefon = korisnikBO.Telefon;
            korisnik.Email = korisnikBO.Email;
            korisnik.Nivo = korisnikBO.Nivo;
            kjfzEntities.Korisnik.Update(korisnik);
            kjfzEntities.SaveChanges();
        }

        public bool KorisnikExists(string id) //Da li postoji korisnik u bazi
        {
            return kjfzEntities.Korisnik.Any(e => e.KorisnikId == id);
        }

        public bool KorisnikPrijava(string id, string lozinka) //Da li moze da se prijavi
        {
            return kjfzEntities.Korisnik.Any(u => u.KorisnikId == id && u.Lozinka == lozinka && u.Nivo > 0);
        }

        public int KorisnikNivo(string id) //Vraca nivo korisnika
        {
            return kjfzEntities.Korisnik.Where(x => x.KorisnikId == id).Select(p => new { p.Nivo }).ToList().First().Nivo;
        }

        public IEnumerable<KorisnikBO> KorisnikGetFrizer() //Vraca sve fizere
        {
            List<KorisnikBO> korisnici = new List<KorisnikBO>();

            foreach (Korisnik korisnik in kjfzEntities.Korisnik.Where(u => u.Nivo == 2))
            {
                korisnici.Add(new KorisnikBO
                {
                    KorisnikId = korisnik.KorisnikId,
                    Lozinka = korisnik.Lozinka,
                    Ime = korisnik.Ime,
                    Prezime = korisnik.Prezime,
                    DatumRodjenja = korisnik.DatumRodjenja,
                    Telefon = korisnik.Telefon,
                    Email = korisnik.Email,
                    Nivo = korisnik.Nivo
                });
            }
            return korisnici;
        }

        #endregion

        #region Usluga
        public IEnumerable<UslugaBO> UslugaGetAll() //Vraca sve usluge
        {
            List<UslugaBO> usluge = new List<UslugaBO>();

            foreach (Usluga usluga in kjfzEntities.Usluga)
            {
                usluge.Add(new UslugaBO
                {
                    UslugaId = usluga.UslugaId,
                    Cena = usluga.Cena,
                    Trajanje = usluga.Trajanje,
                    Opis = usluga.Opis,
                    Aktivna = usluga.Aktivna
                });
            }
            return usluge;
        }

        public bool UslugaExists(string id) //Da li postoji usluga
        {
            return kjfzEntities.Usluga.Any(e => e.UslugaId == id);
        }

        public UslugaBO UslugaGetById(string id) //Uzima uslugu po id-ju
        {
            UslugaBO uslugaBO = new UslugaBO();
            var usluga = kjfzEntities.Usluga.First(m => m.UslugaId == id);
            if (usluga != null)
            {
                uslugaBO.UslugaId = usluga.UslugaId;
                uslugaBO.Cena = usluga.Cena;
                uslugaBO.Trajanje = usluga.Trajanje;
                uslugaBO.Opis = usluga.Opis;
                uslugaBO.Aktivna = usluga.Aktivna;
            }
            return uslugaBO;
        }

        public void UslugaUpdate(UslugaBO uslugaBO) //Azurira uslugu
        {
            Usluga usluga = new Usluga();
            usluga.UslugaId = uslugaBO.UslugaId;
            usluga.Cena = uslugaBO.Cena;
            usluga.Trajanje = uslugaBO.Trajanje;
            usluga.Opis = uslugaBO.Opis;
            usluga.Aktivna = uslugaBO.Aktivna;
            kjfzEntities.Usluga.Update(usluga);
            kjfzEntities.SaveChanges();
        }

        public void UslugaAdd(UslugaBO uslugaBO) //Dodaje uslugu
        {
            Usluga usluga = new Usluga();
            usluga.UslugaId = uslugaBO.UslugaId;
            usluga.Cena = uslugaBO.Cena;
            usluga.Trajanje = uslugaBO.Trajanje;
            usluga.Opis = uslugaBO.Opis;
            usluga.Aktivna = uslugaBO.Aktivna;
            kjfzEntities.Usluga.Add(usluga);
            kjfzEntities.SaveChanges();
        }

        public IEnumerable<UslugaBO> UslugaGetAktivna() //Vraca aktivne usluge
        {
            List<UslugaBO> usluge = new List<UslugaBO>();

            foreach (Usluga usluga in kjfzEntities.Usluga.Where(u => u.Aktivna == true))
            {
                System.Diagnostics.Debug.WriteLine(usluga.UslugaId);
                usluge.Add(new UslugaBO
                {
                    UslugaId = usluga.UslugaId,
                    Cena = usluga.Cena,
                    Trajanje = usluga.Trajanje,
                    Opis = usluga.Opis,
                    Aktivna = usluga.Aktivna
                });
            }
            return usluge;
        }

        #endregion

        #region Termin
        public IEnumerable<TerminBO> TerminGetAll() //Vraca sve termine
        {
            List<TerminBO> termini = new List<TerminBO>();

            foreach (Termin termin in kjfzEntities.Termin.OrderBy(u => u.Vreme).OrderBy(u => u.Datum))
            {
                termini.Add(new TerminBO
                {
                    TerminId = termin.TerminId,
                    UslugaId = termin.UslugaId,
                    KorisnikId = termin.KorisnikId,
                    Datum = termin.Datum,
                    Vreme = termin.Vreme,
                    Uradjeno = termin.Uradjeno,
                    KorisnikFrizerId = termin.KorisnikFrizerId
                });
            }
            return termini;
        }

        public IEnumerable<TerminBO> TerminGetForFrizer(string id) //Vraca termine po frizeru
        {
            List<TerminBO> termini = new List<TerminBO>();

            foreach (Termin termin in kjfzEntities.Termin.Where(u => u.KorisnikFrizerId == id).OrderBy(u => u.Vreme).OrderBy(u => u.Datum))
            {
                termini.Add(new TerminBO
                {
                    TerminId = termin.TerminId,
                    UslugaId = termin.UslugaId,
                    KorisnikId = termin.KorisnikId,
                    Datum = termin.Datum,
                    Vreme = termin.Vreme,
                    Uradjeno = termin.Uradjeno,
                    KorisnikFrizerId = termin.KorisnikFrizerId
                });
            }
            return termini;
        }

        public IEnumerable<TerminBO> TerminGetForKlijent(string id) //Vraca termine ko klijentu
        {
            List<TerminBO> termini = new List<TerminBO>();

            foreach (Termin termin in kjfzEntities.Termin.Where(u => u.KorisnikId == id).OrderBy(u => u.Vreme).OrderBy(u => u.Datum))
            {
                termini.Add(new TerminBO
                {
                    TerminId = termin.TerminId,
                    UslugaId = termin.UslugaId,
                    KorisnikId = termin.KorisnikId,
                    Datum = termin.Datum,
                    Vreme = termin.Vreme,
                    Uradjeno = termin.Uradjeno,
                    KorisnikFrizerId = termin.KorisnikFrizerId
                });
            }
            return termini;
        }

        public bool TerminExists(int? id) //Da li postoji termin
        {
            return kjfzEntities.Termin.Any(e => e.TerminId == id);
        }

        public TerminBO TerminGetById(int? id) //Vraca termin po id-ju
        {
            TerminBO terminBO = new TerminBO();
            var termin = kjfzEntities.Termin.First(m => m.TerminId == id);
            if (termin != null)
            {
                terminBO.TerminId = termin.TerminId;
                terminBO.UslugaId = termin.UslugaId;
                terminBO.KorisnikId = termin.KorisnikId;
                terminBO.Datum = termin.Datum;
                terminBO.Vreme = termin.Vreme;
                terminBO.Uradjeno = termin.Uradjeno;
                terminBO.KorisnikFrizerId = termin.KorisnikFrizerId;
            }
            return terminBO;
        }

        public void TerminAdd(TerminBO terminBO) //Dodaje termin
        {
            Termin termin = new Termin();
            termin.TerminId = terminBO.TerminId;
            termin.UslugaId = terminBO.UslugaId;
            termin.KorisnikId = terminBO.KorisnikId;
            termin.Datum = terminBO.Datum;
            termin.Vreme = terminBO.Vreme;
            termin.Uradjeno = terminBO.Uradjeno;
            termin.KorisnikFrizerId = terminBO.KorisnikFrizerId;
            kjfzEntities.Termin.Add(termin);
            kjfzEntities.SaveChanges();
        }

        public void TerminUpdate(TerminBO terminBO) //Azurira termin
        {
            Termin termin = new Termin();
            termin.TerminId = terminBO.TerminId;
            termin.UslugaId = terminBO.UslugaId;
            termin.KorisnikId = terminBO.KorisnikId;
            termin.Datum = terminBO.Datum;
            termin.Vreme = terminBO.Vreme;
            termin.Uradjeno = terminBO.Uradjeno;
            termin.KorisnikFrizerId = terminBO.KorisnikFrizerId;
            kjfzEntities.Termin.Update(termin);
            kjfzEntities.SaveChanges();
        }

        public void TerminDelete(int id) //Brise termin
        {
            var termin = kjfzEntities.Termin.Find(id);
            kjfzEntities.Termin.Remove(termin);
            kjfzEntities.SaveChanges();
        }

        public IEnumerable<TerminBO> TerminGetZauzeti(string id, DateOnly datum) //Vraca zauzete termine
        {
            List<TerminBO> termini = new List<TerminBO>();

            foreach (Termin termin in kjfzEntities.Termin.Where(u => u.KorisnikFrizerId == id && u.Datum.CompareTo(datum) == 0)
                    .OrderBy(u => u.Vreme))
            {
                termini.Add(new TerminBO
                {
                    TerminId = termin.TerminId,
                    UslugaId = termin.UslugaId,
                    KorisnikId = termin.KorisnikId,
                    Datum = termin.Datum,
                    Vreme = termin.Vreme,
                    Uradjeno = termin.Uradjeno,
                    KorisnikFrizerId = termin.KorisnikFrizerId
                });
            }
            return termini;
        }


        #endregion

        #endregion
    }

}
