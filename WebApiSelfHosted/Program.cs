using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;

namespace WebApiSelfHosted
{
    public class Program
    {
        public static void Main()
        {
            var baseAddress = "http://localhost:9000/";
            // Start OWIN host 
            using (WebApp.Start<EntryPoint>(url: baseAddress))
            {
                // Create HttpCient and make a request to api/values 
                var client = new HttpClient();
                var response = client.GetAsync(baseAddress + "api/TestApi").Result;
                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }
            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
