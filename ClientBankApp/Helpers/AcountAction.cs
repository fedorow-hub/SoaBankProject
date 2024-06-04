using ClientBankApp.Models.Account;
using Newtonsoft.Json;
using System.Net.Http;

namespace ClientBankApp.Helpers
{
    public class AcountAction
    {
        public static AccountList GetClientAccounsts(Guid id)
        {
            HttpResponseMessage response = MyHttpClient.htmlClient.GetAsync($"account/getall/{id}").Result;

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

        public static string CreateAccount(Account account)
        {
            HttpResponseMessage response = MyHttpClient.htmlClient.PostAsJsonAsync("account/create", account).Result;

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return "Ошибка создания счета";
            }
        }

        public static string DeleteAccount(Guid id)
        {
            HttpResponseMessage response = MyHttpClient.htmlClient.DeleteAsync($"account/delete/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return "Ошибка создания счета";
            }
        }

        public static string WithdrawalMoney(AmountDelta amountDelta)
        {
            HttpResponseMessage response = MyHttpClient.htmlClient.PutAsJsonAsync("account/WithdrawMoney", amountDelta).Result;

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return "Ошибка снятия со счета";
            }
        }

        public static string AddMoney(AmountDelta amountDelta)
        {
            HttpResponseMessage response = MyHttpClient.htmlClient.PutAsJsonAsync("account/AddMoney", amountDelta).Result;

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return "Ошибка внесения средств на счет";
            }
        }

        public static string TransactionMoney(TransactionModel transactionModel)
        {
            HttpResponseMessage response = MyHttpClient.htmlClient.PutAsJsonAsync("account/TransactionMoney", transactionModel).Result;

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return "Ошибка перевода средств";
            }
        }
    }
}
