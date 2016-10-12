using IS.Transactions.Demo.Core.Interface.Client;
using IS.Transactions.Demo.Core.Model;
using IS.Transactions.Demo.Web.UI.Helpers;
using System.Net.Http;

namespace IS.Transactions.Demo.Web.UI.Client.WebAPIClient
{
    public class PersonClient : IPersonClient
    {
        private readonly string _apiController;

        public PersonClient()
        {
            _apiController = "Person";
        }
        public void CreatePerson(Person personToAdd)
        {
            var requestUrl = string.Format("{0}/CreatePerson", _apiController);
            var response = ClientHelper.PerformPostRequest(requestUrl, personToAdd);
        }

        public Person[] FindPeople(SearchCriteria criteria)
        {
            var requestUrl = string.Format("{0}/FindPeople", _apiController);
            var response = ClientHelper.PerformPostRequest(requestUrl, criteria);

            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<Person[]>().Result;
            return null;
        }

        public Person FindPersonByCode(int code)
        {
            var requestUrl = string.Format("{0}/FindPersonByCode?code={1}", _apiController, code);
            var response = ClientHelper.PerformGetRequest(requestUrl);

            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<Person>().Result;
            return null;
        }

        public void RemovePerson(Person personToRemove)
        {
            var requestUrl = string.Format("{0}/RemovePerson", _apiController);
            var response = ClientHelper.PerformPostRequest(requestUrl, personToRemove);
        }

        public void UpdatePerson(Person personToUpdate)
        {
            var requestUrl = string.Format("{0}/UpdatePerson", _apiController);
            var response = ClientHelper.PerformPostRequest(requestUrl, personToUpdate);
        }
    }
}