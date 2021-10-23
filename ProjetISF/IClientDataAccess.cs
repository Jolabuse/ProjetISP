using System.Collections.Generic;
using ProjetISF.Person;

namespace ProjetISF
{
    public interface IClientDataAccess
    {
        List<Client> GetAll();
        void CreateUser(string firstname,string name, int pin, string currency, List<Money> money);
        Client GetClient(string guid);
        void UpdateClient(Client c);
        void DeleteClient(string guid);
    }
}