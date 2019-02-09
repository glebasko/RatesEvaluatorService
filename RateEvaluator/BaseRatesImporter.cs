using RateEvaluator.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace RateEvaluator
{
    public class BaseRatesImporter
    {

        public static async Task<IEnumerable<BaseRate>> ImportLatestBaseRatesAsync()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://www.lb.lt");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));

            IEnumerable<BaseRate> baseRates = null;
            string result = null;

            HttpResponseMessage response = await client.GetAsync("/webservices/VilibidVilibor/VilibidVilibor.asmx/getVilibRatesByDate?Date=");
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }

             return baseRates;
        }
    }
}