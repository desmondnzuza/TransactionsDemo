using IS.Transactions.Demo.Core.Interface.Client;
using IS.Transactions.Demo.Core.Model;
using IS.Transactions.Demo.Web.UI.Helpers;
using System.Net.Http;

namespace IS.Transactions.Demo.Web.UI.Client.WebAPIClient
{
    public class AccountClient : IAccountClient
    {
        private readonly string _apiController;

        public AccountClient()
        {
            _apiController = "Account";
        }

        public void CreateAccount(Account accountToAdd)
        {
            var requestUrl = string.Format("{0}/CreateAccount", _apiController);
            var response = ClientHelper.PerformPostRequest(requestUrl, accountToAdd);
            
            var result = response.IsSuccessStatusCode;
        }

        public Account FindAccountByCode(int code)
        {
            var requestUrl = string.Format("{0}/FindAccountByCode?code={1}", _apiController, code);
            var response = ClientHelper.PerformGetRequest(requestUrl);

            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<Account>().Result;
            return null;
        }

        public Account[] FindAccounts(SearchCriteria criteria)
        {
            var requestUrl = string.Format("{0}/FindAccounts", _apiController);
            var response = ClientHelper.PerformPostRequest(requestUrl, criteria);

            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<Account[]>().Result;
            return null;
        }

        public Person[] FindAvailablePeople()
        {
            var requestUrl = string.Format("{0}/FindAvailablePeople", _apiController);
            var response = ClientHelper.PerformGetRequest(requestUrl);


            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<Person[]>().Result;
            return null;
        }

        public void RemoveAccount(Account accountToRemove)
        {
            var requestUrl = string.Format("{0}/RemoveAccount", _apiController);
            var response = ClientHelper.PerformPostRequest(requestUrl, accountToRemove);
        }

        public void UpdateAccount(Account accountToUpdate)
        {
            var requestUrl = string.Format("{0}/UpdateAccount", _apiController);
            var response = ClientHelper.PerformPostRequest(requestUrl, accountToUpdate);
        }
    }
}