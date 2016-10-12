using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace IS.Transactions.Demo.Web.UI.Helpers
{
    public static class ClientHelper
    {
        private const string _apiURL = "http://localhost:57081/api/";

        public static HttpResponseMessage PerformPostRequest<T>(string requestUrl, T input)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_apiURL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client.PostAsJsonAsync(requestUrl, input).Result;
        }

        public static HttpResponseMessage PerformGetRequest(string requestUrl)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_apiURL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client.GetAsync(requestUrl).Result;
        }
    }
}