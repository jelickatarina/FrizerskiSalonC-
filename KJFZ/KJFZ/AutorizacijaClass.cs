using KJFZ.Data;
using Microsoft.AspNetCore.Http;

namespace KJFZ
{
    public class AutorizacijaClass
    {
        public bool Autorizacija(HttpContext hContext, int pNivo) //Proverava nivo korisnika
        {
            bool res=false;
            if (hContext.Session.Keys.Count() != 0)
                if (!hContext.Session.Get<String>("KorisnikId").Equals("") && hContext.Session.Get<int>("Nivo")>=pNivo)
                    res = true;
            return res;
        }

    }
}
