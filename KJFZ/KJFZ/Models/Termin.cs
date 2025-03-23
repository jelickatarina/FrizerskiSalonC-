using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KJFZ.Models
{
    // Unique index
    [Index(nameof(Datum), nameof(Vreme), nameof(KorisnikFrizerId), IsUnique = true, Name="TerminUniqueIndex")]
    public class Termin
    {
        // [Key] // TREBA AKO JE NPR. TerminiId
        public int TerminId { get; set; }
        public String UslugaId { get; set; }
        public String KorisnikId { get; set; }
        public DateOnly Datum { get; set; }
        public int Vreme { get; set; }
        public bool Uradjeno { get; set; }
        public String KorisnikFrizerId { get; set; }

        public virtual Usluga Usluga { get; set; }
        public virtual Korisnik Korisnik{ get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual Korisnik KorisnikFrizer { get; set; }

        /*
        // Mora ovako, jer se buni ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Usluga Usluga { get; set; }
        */

        /* PRIMER ZA 2 FK OD JEDNE TABELE KorisnikId
        public String? KorisnikUneoId { get; set; }
        public String? KorisnikUradioId { get; set; }

        public virtual Korisnik KorisnikUneo { get; set; }
        public virtual Korisnik KorisnikUradio { get; set; }
        */
    }
}