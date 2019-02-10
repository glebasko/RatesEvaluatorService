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
        private static HttpClient ConfigureHttpClient()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:50754/");
            client.DefaultRequestHeaders.Accept.Clear();

            return client;
        }

        public static async Task<IEnumerable<Agreement>> GetAgreementsAsync(string path)
        {
            HttpResponseMessage response = null;
            using (HttpClient client = ConfigureHttpClient())
            {
                 response = await client.GetAsync(path);
            }

            IEnumerable<Agreement> agreements = null;
            if (response.IsSuccessStatusCode)
            {
                agreements = await response.Content.ReadAsAsync<IEnumerable<Agreement>>();
            }

            return agreements;       
        }

        public static async Task<Agreement> GetAgreementAsync(string path)
        {
            HttpResponseMessage response = null;
            using (HttpClient client = ConfigureHttpClient())
            {
                response = await client.GetAsync(path);
            }

            Agreement agreement = null;
            if (response.IsSuccessStatusCode)
            {
                agreement = await response.Content.ReadAsAsync<Agreement>();
            }
            
            return agreement;
        }

        public static async Task<AgreementExtended> UpdateAgreementBaseRate(string path, BaseRate.RateType newBaseRateType)
        {
            HttpResponseMessage response = null;
            using (HttpClient client = ConfigureHttpClient())
            {        
                response = await client.PutAsJsonAsync(path, newBaseRateType);
            }

            AgreementExtended result = null;
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<AgreementExtended>();
            }

            return result;
        }
    }
}