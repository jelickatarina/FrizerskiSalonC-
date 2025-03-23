using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KJFZ.Models;

namespace KJFZ.Models
{
    public class KorisnikBO
    {
        public String KorisnikId { get; set; }
        public String Lozinka { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        
        public DateOnly DatumRodjenja { get; set; }
        public String Telefon { get; set; }
        public String Email { get; set; }
        [AllowedValues(0,1,2,9)]
        public int Nivo { get; set; }
    }
}
