using AdministrareDate;
using Aplicatie_Magazin_Instrumente_Muzicale;
namespace Magazin
{
    class Program
    {
        public static void Main()
        {
            List<Instrument> instruments = new List<Instrument>();
            Instrument? instrumentNou = null;
            List<Client> clients = new List<Client>();
            IStocareDate adminClienti = StocareFactory.GetAdministratorStocare();
            Client? clientNou = null;

            string optiune;

            do
            {
                Console.WriteLine("INSTRUMENTE");
                Console.WriteLine("C. Citire informatii instrument:");
                Console.WriteLine("I. Afisarea informatii instrument");
                Console.WriteLine("A. Afisare instrumentele din lista");
                Console.WriteLine("S. Salvare instrument in lista");
                Console.WriteLine("CLIENTI");
                Console.WriteLine("C1.Citire info client");
                Console.WriteLine("S1.Salvare info client");
                Console.WriteLine("I1.Info client");
                Console.WriteLine("A1. Afisare clientii din lista");
                Console.WriteLine("P. Afisare parola");

                Console.WriteLine("X. Inchidere program");

                Console.WriteLine("Alegeti o optiune");
                optiune = Console.ReadLine()?.ToUpper() ?? string.Empty;

                switch (optiune)
                {
                    case "C":
                        instrumentNou = CitireInstrumentTastatura();
                        break;
                    case "C1":
                        clientNou = CitireClientTastatura();
                        break;

                    case "I":
                        AfisareInstrument(instrumentNou);
                        break;
                    case "I1":
                        AfisareClient(clientNou);
                        break;
                    case "A":
                        AfisareInstrumente(instruments);
                        break;
                    case "A1":
                        var clienti = adminClienti.GetClienti();
                        AfisareClienti(clienti);
                        break;
                    case "S":
                        instrumentNou.ID = instruments.Count + 1;
                        instruments.Add(instrumentNou);
                        Console.WriteLine("Instrument salvat");
                        break;
                    case "S1":
                        clientNou.ID = clients.Count + 1;
                        if (clientNou != null)
                        {
                            adminClienti.AdaugaClient(clientNou);
                            Console.WriteLine("Client salvat in fisier");
                        }

                        Console.WriteLine("Client salvat");
                        break;
                    case "P":
                        Console.WriteLine("Introduceti username-ul:");
                        string nume = Console.ReadLine();
                        Console.WriteLine("Introduceti email-ul:");
                        string email = Console.ReadLine();
                        var listaClienti = adminClienti.GetClienti();
                        string parolaGasita = GetPassword(clients, email, nume);
                        if (parolaGasita != null)
                        {
                            Console.WriteLine($"Parola: {parolaGasita}");
                        }
                        else
                        {
                            Console.WriteLine("Nu a fost gasit contul");
                        }
                        break;

                    case "X":
                        Console.WriteLine("Close");
                        return;
                    default:
                        Console.WriteLine("Optiune inexistenta");
                        break;

                }

            } while (optiune.ToUpper() != "X");
            Console.ReadKey();
        }
        public static Instrument CitireInstrumentTastatura()
        {
            Console.WriteLine("Introduceti numele:");
            string nume = Console.ReadLine();
            Console.WriteLine("Introduceti brandul:");
            string brand = Console.ReadLine();
            Console.WriteLine("Introduceti price:");
            double.TryParse(Console.ReadLine(), out double price);

            Console.WriteLine("Introduceti discount:");
            double.TryParse(Console.ReadLine(), out double discount);
            Console.WriteLine("Introduceti cantitate:");
            int.TryParse(Console.ReadLine(), out int cantitate);

            Instrument instrument = new Instrument(nume, brand, price, 0, discount, cantitate);
            return instrument;

        }
        public static Client CitireClientTastatura()
        {
            Console.WriteLine("Introduceti username-ul:");
            string nume = Console.ReadLine();
            Console.WriteLine("Introduceti email-ul:");
            string email = Console.ReadLine();
            Client client = new Client(0, nume, email);
            Console.WriteLine("Introduceti o parola:");
            string parola = Console.ReadLine();
            client.SetPassword(parola);
            return client;


        }
        public static void AfisareInstrument(Instrument instrument)
        {
            Console.WriteLine(instrument.Info());
        }
        public static void AfisareClient(Client client)
        {
            Console.WriteLine(client.Info());
        }
        public static void AfisareInstrumente(List<Instrument> instrumente)
        {
            Console.WriteLine("Instrumentele sunt:");
            foreach (Instrument instrument in instrumente)
            {
                AfisareInstrument(instrument);
            }
        }
        public static void AfisareClienti(List<Client> clienti)
        {
            Console.WriteLine("Clientii sunt:");
            foreach (Client client in clienti)
            {
                AfisareClient(client);
            }
        }
        public static string GetPassword(List<Client> clients, string email, string nume)
        {
            foreach (Client client in clients)
            {
                if (client.Name.ToLower() == nume.ToLower() && client.Email.ToLower() == email.ToLower())
                {
                    return client.GetPass();
                }
            }
            return null;
        }


    }
}

