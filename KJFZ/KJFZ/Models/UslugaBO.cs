using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KJFZ.Models
{
    public class UslugaBO
    {
        public String UslugaId { get; set; }
        public int Cena { get; set; }
        public int Trajanje { get; set; }
        public string Opis { get; set; }
        public bool Aktivna { get; set; }
    }
}
