

using System.Collections.Generic;
using ProjetISF.Person;

namespace ProjetISF.Json
{
    public class ClientJsonAccess : IClientDataAccess
    {
        public List<Client> GetAll()
        {
            //TODO
            return new List<Client>();
        }

        public void CreateUser(string firstname,string name, int pin, string currency, List<Money> money)
        {
            //ToDO
        }

        public Client GetClient(string guid)
        {
            //TODO
            return new Client();
        }

        public void UpdateClient(Client c)
        {
            //TODO
        }

        public void DeleteClient(string guid)
        {
            //TODO
        }
    }
}