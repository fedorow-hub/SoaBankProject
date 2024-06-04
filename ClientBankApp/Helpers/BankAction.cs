using ClientBankApp.Models.Bank;
using Newtonsoft.Json;
using System.Net.Http;

namespace ClientBankApp.Helpers
{
    public class BankAction
    {
        public static Bank CreateBank(Bank bank)
        {
            HttpResponseMessage response = MyHttpClient.htmlClient.PostAsJsonAsync("bank/create", bank).Result;

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
    }
}
