using System;
using System.Collections.Generic;
using System.Text;
using Aplicatie_Magazin_Instrumente_Muzicale;

namespace AdministrareDate
{
    public interface IStocareDate
    {
        void AdaugaClient(Client c);
        List<Client> GetClienti();
        List<Client> CautaClientDupaNume(List<Client> clienti, string nume);
        bool StergeClientDupaNume(string nume);
    }
}
