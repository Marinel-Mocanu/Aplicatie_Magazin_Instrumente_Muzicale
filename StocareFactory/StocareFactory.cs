using System.IO;
using AdministrareDate;

namespace Aplicatie_Magazin_Instrumente_Muzicale
{
    public static class StocareFactory
    {
        public static IStocareDate GetAdministratorStocare()
        {

            bool folosesteFisier = true; // false = memorie

            if (folosesteFisier)
            {
                string numeFisier = "clienti.txt";
                return new AdministrareDateText(numeFisier);
            }
            else
            {
                return new AdministrareDateMemorie();
            }
        }
    }
}
