using Aplicatie_Magazin_Instrumente_Muzicale;
using System.Diagnostics.Metrics;
using System.Linq;
namespace AdministrareDate
{
    public class AdministrareDateMemorie : IStocareDate
    {
        private List<Client> clienti;

        public AdministrareDateMemorie()
        {
            clienti = new List<Client>();
        }
        public void AdaugaClient(Client client)
        {
            clienti.Add(client);
        }
        public List<Client> GetClienti()
        {
            if (clienti == null)
            {
                clienti = new List<Client>();
            }
            return clienti;
        }
        public List<Client> CautaClientDupaNume(List<Client> clienti, string nume)
        {
            return clienti.Where(c => c.Name == nume).ToList();


        }
        public bool StergeClientDupaNume(string nume)
        {
            var client = clienti.FirstOrDefault(c => c.Name == nume);
            if (client != null)
            {
                clienti.Remove(client);
                return true;
            }
            return false;
        }
    }
}
