using IS.Transactions.Demo.Core.Interface.Client;
using IS.Transactions.Demo.Core.Model;
using IS.Transactions.Demo.Web.UI.Helpers;
using System.Net.Http;

namespace IS.Transactions.Demo.Web.UI.Client.WebAPIClient
{
    public class TransactionClient : ITransactionClient
    {
        private readonly string _apiController;

        public TransactionClient()
        {
            _apiController = "Transaction";
        }
        public void CreateTransaction(Transaction transactionToAdd)
        {
            var requestUrl = string.Format("{0}/CreateTransaction", _apiController);
            var response = ClientHelper.PerformPostRequest(requestUrl, transactionToAdd);
        }

        public Account[] FindAvailableAccounts()
        {
            var requestUrl = string.Format("{0}/FindAvailableAccounts", _apiController);
            var response = ClientHelper.PerformGetRequest(requestUrl);

            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<Account[]>().Result;
            return null;
        }

        public Transaction FindTransactionByCode(int code)
        {
            var requestUrl = string.Format("{0}/FindTransactionByCode?code={1}", _apiController, code);
            var response = ClientHelper.PerformGetRequest(requestUrl);

            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<Transaction>().Result;
            return null;
        }

        public Transaction[] FindTransactions(SearchCriteria criteria)
        {
            var requestUrl = string.Format("{0}/FindTransactions", _apiController);
            var response = ClientHelper.PerformPostRequest(requestUrl, criteria);

            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<Transaction[]>().Result;
            return null;
        }

        public void RemoveTransaction(Transaction transactionToRemove)
        {
            var requestUrl = string.Format("{0}/RemoveTransaction", _apiController);
            var response = ClientHelper.PerformPostRequest(requestUrl, transactionToRemove);
        }

        public void UpdateTransaction(Transaction transactionToUpdate)
        {
            var requestUrl = string.Format("{0}/UpdateTransaction", _apiController);
            var response = ClientHelper.PerformPostRequest(requestUrl, transactionToUpdate);
        }
    }
}