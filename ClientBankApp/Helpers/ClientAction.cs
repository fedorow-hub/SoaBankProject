using ClientBankApp.Models.Client;
using Newtonsoft.Json;
using System.Net.Http;

namespace ClientBankApp.Helpers
{
    public class ClientAction
    {
        public static ClientList GetClients()
        {
            HttpResponseMessage response = MyHttpClient.htmlClient.GetAsync("client/getall").Result;

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

        public static bool DeleteClient(Guid clientId)
        {
            HttpResponseMessage response = MyHttpClient.htmlClient.DeleteAsync($"client/delete/{clientId}").Result;

            if (response.IsSuccessStatusCode)
            {
                if (response.Content.ReadAsStringAsync().Result == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool CreateClient(Client client)
        {
            HttpResponseMessage response = MyHttpClient.htmlClient.PostAsJsonAsync("client/create", client).Result;

            if (response.IsSuccessStatusCode)
            {
                if (response.Content.ReadAsStringAsync().Result == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool UpdateClient(Client client)
        {
            HttpResponseMessage response = MyHttpClient.htmlClient.PutAsJsonAsync("client/update", client).Result;

            if (response.IsSuccessStatusCode)
            {
                if (response.Content.ReadAsStringAsync().Result == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
