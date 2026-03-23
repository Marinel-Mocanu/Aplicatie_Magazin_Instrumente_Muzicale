namespace Aplicatie_Magazin_Instrumente_Muzicale;

using System.Linq;
using System.Collections.Generic;

public class Client
{
    private string Password;
    public int ID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public void SetPassword(string _pass)
    {
        Password = _pass;
    }


    public Client()
    {
        ID = 0;
        Name = string.Empty;
        Email = string.Empty;
        Password = string.Empty;

    }
    public Client(int IdC, string NameC, string EmailC)
    {
        ID = IdC;
        Name = NameC;
        Email = EmailC;

    }
    public string GetPass()
    {
        return Password;
    }
    public static List<Client> CautaClientDupaNume(List<Client> clienti,string nume)
    {
        return clienti.Where(c=>c.Name== nume).ToList();
    }
    public string Info()
    {
        string info = $"ID:{ID} Nume:{Name} Email:{Email}";
        return info;
    }


}
