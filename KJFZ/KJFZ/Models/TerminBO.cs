using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KJFZ.Models
{
    // Unique index
    [Index(nameof(Datum), nameof(Vreme), nameof(KorisnikFrizerId), IsUnique = true, Name="TerminUniqueIndex")]
    public class TerminBO
    {
        public int TerminId { get; set; }
        public String UslugaId { get; set; }
        public String KorisnikId { get; set; }
        public DateOnly Datum { get; set; }
        public int Vreme { get; set; }
        public bool Uradjeno { get; set; }
        public String KorisnikFrizerId { get; set; }

        public virtual Usluga Usluga { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public virtual Korisnik KorisnikFrizer { get; set; }

    }
}