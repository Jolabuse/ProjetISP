using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace ProjetISF.Json
{
    public class ApiAccess
    {
        
        public Root objectRes { get; set; }
        
        public JsonHelper js { get; set; }

        private static readonly HttpClient Client = new HttpClient();
        
        private static string apikey = "5cd953afba0a80987318d109";
        

        
        public  async void Getchange(string currency1,string currency2,string amount)
        {
            objectRes = new Root();
            js = new JsonHelper();

            var responseBody = Client.GetAsync("https://v6.exchangerate-api.com/v6/"+apikey+"/pair/"+currency1+"/"+currency2+"/"+amount).Result;
            var res = await responseBody.Content.ReadAsStringAsync();
            objectRes = js.Deserialize(res);


        }
        static void test(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            var p = new ApiAccess();
            p.Getchange("USD", "EUR", "1000");
            Console.WriteLine(p.objectRes.conversion_result);

        }
    }
}