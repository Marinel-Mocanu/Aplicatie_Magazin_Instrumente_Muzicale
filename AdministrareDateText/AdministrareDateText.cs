using Aplicatie_Magazin_Instrumente_Muzicale;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdministrareDate
{
    public class AdministrareDateText : IStocareDate
    {
        private const int ID_PRIMUL_CLIENT = 1;
        private const int INCREMENT = 1;

        private string numeFisier;

        public AdministrareDateText(string numeFisier)
        {
            this.numeFisier = numeFisier;

            Stream stream = File.Open(numeFisier, FileMode.OpenOrCreate);
            stream.Close();
        }

        public void AdaugaClient(Client client)
        {
            client.ID = GetNextId();

            using (StreamWriter sw = new StreamWriter(numeFisier, true))
            {
                sw.WriteLine($"{client.ID};{client.Name};{client.Email}");
            }
        }

        public List<Client> GetClienti()
        {
            List<Client> clienti = new List<Client>();

            using (StreamReader sr = new StreamReader(numeFisier))
            {
                string linie;

                while ((linie = sr.ReadLine()) != null)
                {
                    string[] date = linie.Split(';');

                    Client c = new Client(
                        int.Parse(date[0]),
                        date[1],
                        date[2]
                    );

                    clienti.Add(c);
                }
            }

            return clienti;
        }

        public Client GetClient(string nume)
        {
            using (StreamReader sr = new StreamReader(numeFisier))
            {
                string linie;

                while ((linie = sr.ReadLine()) != null)
                {
                    string[] date = linie.Split(';');

                    Client c = new Client(
                        int.Parse(date[0]),
                        date[1],
                        date[2]
                    );

                    if (c.Name.Equals(nume, StringComparison.OrdinalIgnoreCase))
                        return c;
                }
            }

            return null;
        }
        public List<Client> CautaClientDupaNume(List<Client> clienti, string nume)
        {
            return clienti
                .Where(c => c.Name.Equals(nume, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }


        public bool StergeClientDupaNume(string nume)
        {
            List<Client> clienti = GetClienti();
            bool sters = false;

            using (StreamWriter sw = new StreamWriter(numeFisier, false))
            {
                foreach (Client c in clienti)
                {
                    if (!c.Name.Equals(nume, StringComparison.OrdinalIgnoreCase))
                    {
                        sw.WriteLine($"{c.ID};{c.Name};{c.Email}");
                    }
                    else
                    {
                        sters = true;
                    }
                }
            }

            return sters;
        }

        public bool UpdateClient(Client clientActualizat)
        {
            List<Client> clienti = GetClienti();
            bool actualizat = false;

            using (StreamWriter sw = new StreamWriter(numeFisier, false))
            {
                foreach (Client c in clienti)
                {
                    if (c.ID == clientActualizat.ID)
                    {
                        sw.WriteLine($"{clientActualizat.ID};{clientActualizat.Name};{clientActualizat.Email}");
                        actualizat = true;
                    }
                    else
                    {
                        sw.WriteLine($"{c.ID};{c.Name};{c.Email}");
                    }
                }
            }

            return actualizat;
        }

        private int GetNextId()
        {
            List<Client> clienti = GetClienti();

            if (clienti.Count == 0)
                return ID_PRIMUL_CLIENT;

            return clienti.Last().ID + INCREMENT;
        }
    }
}
