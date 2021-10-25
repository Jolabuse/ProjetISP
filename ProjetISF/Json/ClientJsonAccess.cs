using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ProjetISF.Database;
using ProjetISF.Person;

namespace ProjetISF.Json
{
    public class ClientJsonAccess : IClientDataAccess
    {
        private string filename = "Client.json";
        public List<Client> GetAll()
        {
            var l = JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(filename));
            return l;
        }

        public void CreateUser(string firstname,string name, string pin, string currency, List<Money> money)
        {
            Client c = new Client();
            Guid g = Guid.NewGuid();
            c.guid = g.ToString();
            c.firstname = firstname;
            c.name = name;
            c.pin = pin;
            c.currency = currency;
            c.money = money;
            var l = JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(filename));
            l.Add(c);
            var jss = JsonConvert.SerializeObject(l, Formatting.Indented);
            File.WriteAllText(filename,jss);
        }

        public Client GetClient(string guid)
        {
            var l = JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(filename));
            foreach (var c in l)
            {
                if (c.guid == guid)
                    return c;
            }

            return null;
        }

        public void UpdateClient(Client c)
        {
            ClientJsonAccess cja = new ClientJsonAccess();
            cja.DeleteClient(c.guid);
            var l = JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(filename));
            l.Add(c);
            var jss = JsonConvert.SerializeObject(l, Formatting.Indented);
            File.WriteAllText(filename,jss);
        }

        public void DeleteClient(string guid)
        {
            var l = JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(filename));
            int i = 0;
            foreach (var c in l)
            {
                if (c.guid == guid)
                {
                    l.Remove(c);
                    break;
                }
            }
            var jss = JsonConvert.SerializeObject(l, Formatting.Indented);
            File.WriteAllText(filename,jss);
        }

        public void FillJson()
        {
            ClientDBAccess cdb = new ClientDBAccess();
            var l = cdb.GetAll();
            var jss = JsonConvert.SerializeObject(l, Formatting.Indented);
            File.WriteAllText(filename,jss);
        }
    }
}