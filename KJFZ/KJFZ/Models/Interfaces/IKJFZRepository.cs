using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KJFZ.Models.Interfaces
{
    interface IKJFZRepository
    {
        IEnumerable<KorisnikBO> KorisnikGetAll();
        KorisnikBO KorisnikGetById(string id);
        void KorisnikAdd(KorisnikBO korisnikBO);
        void KorisnikUpdate(KorisnikBO korisnikBO);
        bool KorisnikExists(string id);
        bool KorisnikPrijava(string id, string lozinka);

        int KorisnikNivo(string id);

        IEnumerable<KorisnikBO> KorisnikGetFrizer();

        IEnumerable<UslugaBO> UslugaGetAll();
        bool UslugaExists(string id);
        UslugaBO UslugaGetById(string id);
        void UslugaAdd(UslugaBO uslugaBO);
        void UslugaUpdate(UslugaBO uslugaBO);

        IEnumerable<UslugaBO> UslugaGetAktivna();

        IEnumerable<TerminBO> TerminGetAll();
        IEnumerable<TerminBO> TerminGetForFrizer(string id);
        IEnumerable<TerminBO> TerminGetForKlijent(string id);
        bool TerminExists(int? id);
        TerminBO TerminGetById(int id);
        void TerminAdd(TerminBO terminBO);
        void TerminUpdate(TerminBO terminBO);
        void TerminDelete(int id);

        IEnumerable<TerminBO> TerminGetZauzeti(string id, DateOnly datum);
    }
}
