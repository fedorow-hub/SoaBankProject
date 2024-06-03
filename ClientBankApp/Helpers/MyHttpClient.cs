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
        static HttpClient client = new HttpClient();

        public static void InitialiseHttpClient(string url)
        {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static Bank CreateBank(Bank bank)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("bank/create", bank).Result;

            if (response.IsSuccessStatusCode)
            {
                var responceContent = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<Bank>(responceContent);
            }
            else
            {
                return null;
            }
        }

        public static ClientList GetClients()
        {
            HttpResponseMessage response = client.GetAsync("client/getall").Result;

            if (response.IsSuccessStatusCode)
            {
                var responceContent = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<ClientList>(responceContent);
            }
            else
            {
                return null;
            }
        }

        public static AccountList GetClientAccounsts(Guid id)
        {
            HttpResponseMessage response = client.GetAsync($"account/getall/{id}").Result;

            if (response.IsSuccessStatusCode)
            {

                var responceContent = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<AccountList>(responceContent);
            }
            else
            {
                return null;
            }
        }

    }
}
