using System.Collections.Generic;

namespace ProjetISF.Person
{
    public class Client
    {
        public string guid { get; set; }
        public string firstname{ get; set; }
        public string name{ get; set; }
        public int pin{ get; set; }
        public string currency{ get; set; }
        public List<Money> money { get; set; } = new List<Money>();
    }
}