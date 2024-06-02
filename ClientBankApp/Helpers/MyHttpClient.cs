using ClientBankApp.Models.Bank;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

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
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var responceContent = response.Content.ReadAsStringAsync().Result;

                return JsonSerializer.Deserialize<Bank>(responceContent, options);
            }
            else
            {
                return null;
            }
        }
    }
}
