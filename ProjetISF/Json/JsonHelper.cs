using System;
using System.Windows.Documents.Serialization;
using Newtonsoft.Json;

namespace ProjetISF.Json
{
    public class JsonHelper
    {
        public Root Deserialize(string res)
        {
            return JsonConvert.DeserializeObject<Root>(res);
        }
    }
}