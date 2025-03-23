using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KJFZ.Models;

namespace KJFZ.Models
{
    public class Korisnik
    {
        public String KorisnikId { get; set; }
        public String Lozinka { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly DatumRodjenja { get; set; }
        public String Telefon { get; set; }
        public String Email { get; set; }
        public int Nivo { get; set; }
    }
}
