using ClientBankApp.Models.Account;
using ClientBankApp.Models.Bank;
using ClientBankApp.Models.Client;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ClientBankApp.Helpers
{
    public class MyHttpClient
    {
        public static HttpClient htmlClient = new HttpClient();

        public static void InitialiseHttpClient(string url)
        {
            htmlClient.BaseAddress = new Uri(url);
            htmlClient.DefaultRequestHeaders.Accept.Clear();
            htmlClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
