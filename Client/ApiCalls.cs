using RateEvaluator.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace Client
{
    public class ApiCalls
    {
        static HttpClient client;

        static ApiCalls()
        {
            InitHttpClient();
        }

        private static void InitHttpClient()
        {
            client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:50754/");
            client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<IEnumerable<Agreement>> GetProducts(string path)
        {
            IEnumerable<Agreement> agreements = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                agreements = await response.Content.ReadAsAsync<IEnumerable<Agreement>>();
            }

            return agreements;
        }

    }
}