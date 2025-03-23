using KJFZ.Models;

namespace KJFZ.Data
{
    public static class DbInitializer
    {
        public static void Initialize(KJFZContext context)
        {
            context.Database.EnsureCreated(); // Drop and Create

            // Ako nema ni jednog korisnika, dodaj korisnike

            if (!context.Korisnik.Any())
            {
                var korisnici = new Korisnik[]
                {
                    new Korisnik{KorisnikId="Kaca",Lozinka="Kaca",Ime="Katarina",Prezime="Jelic",DatumRodjenja=new DateOnly(2003,6,25),Telefon="065/8501187",Email="jelickat@gmail.com",Nivo=9},
                    new Korisnik{KorisnikId="Frizer1",Lozinka="frizer1",Ime="Jovana",Prezime="Nikolić",DatumRodjenja=new DateOnly(2000,5,20),Telefon="065/6501337",Email="jovananikolic@gmail.com",Nivo=2},
                    new Korisnik{KorisnikId="Klijent1",Lozinka="klijent1",Ime="Sara",Prezime="Stanković",DatumRodjenja=new DateOnly(2001,2,17),Telefon="062/8441157",Email="sarastankovic@gmail.com",Nivo=1}
                };

                foreach (Korisnik k1 in korisnici)
                {
                    context.Korisnik.Add(k1);
                }
                context.SaveChanges();
            } 
            if(!context.Usluga.Any()) //Ako nema ni jedne usluge, dodaj usluge
            {
                var usluge = new Usluga[]
                {
                    new Usluga{UslugaId="Pranje kose", Trajanje=30, Cena=750, Aktivna=true, Opis="Pranje i susenje kose"},
                    new Usluga{UslugaId="Feniranje", Trajanje=45, Cena=1000, Aktivna=true, Opis="Pranje i feniranje kose"},
                    new Usluga{UslugaId="Farbanje", Trajanje=60, Cena=1500, Aktivna=true, Opis="Pranje, farbanje i susenje kose"}
                };

                foreach (Usluga u1 in usluge)
                {
                    context.Usluga.Add(u1);
                }
                context.SaveChanges();
            }
            
        }
    }
}
