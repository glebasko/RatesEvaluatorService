using RateEvaluator.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        public static async Task<IEnumerable<Agreement>> GetAgreementsAsync(string path)
        {
            IEnumerable<Agreement> agreements = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                agreements = await response.Content.ReadAsAsync<IEnumerable<Agreement>>();
            }

            return agreements;
        }

        public static async Task<Agreement> GetAgreementAsync(string path)
        {
            Agreement agreement = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                agreement = await response.Content.ReadAsAsync<Agreement>();
            }

            return agreement;
        }

        public static async Task<AgreementExtended> UpdateAgreementBaseRate(string path, BaseRate.RateType newBaseRateType)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(path, newBaseRateType);

            AgreementExtended result = null;
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<AgreementExtended>();
            }

            return result;
        }
    }
}