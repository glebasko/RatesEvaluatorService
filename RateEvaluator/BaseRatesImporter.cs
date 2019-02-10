using RateEvaluator.SharedModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RateEvaluator
{
    public class BaseRatesImporter
    {
        public static async Task<IEnumerable<BaseRate>> ImportLatestBaseRatesAsync()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            HttpClient client = ConfigureHttpClient();

            HttpResponseMessage response = null;
            string result = null;
            List<BaseRate> baseRates = new List<BaseRate>();

            foreach (string baseRateType in Enum.GetNames(typeof (BaseRate.RateType)))
            {
                response = await client.GetAsync($"/webservices/VilibidVilibor/VilibidVilibor.asmx/getLatestVilibRate?RateType={baseRateType}");

                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }

                BaseRate baseRate = new BaseRate();
                baseRate.Code = (BaseRate.RateType) Enum.Parse(typeof(BaseRate.RateType), baseRateType);
                baseRate.Date = DateTime.Today; 
                baseRate.Value = GetBaseRate(result);

                baseRates.Add(baseRate);
            }

            return baseRates;
        }

        private static HttpClient ConfigureHttpClient()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://www.lb.lt");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));

            return client;
        }

        private static float GetBaseRate(string xmlString)
        {
            XmlRootAttribute xRoot = new XmlRootAttribute("decimal");
            xRoot.Namespace = "http://webservices.lb.lt/VilibidVilibor";

            XmlSerializer serializer = new XmlSerializer(typeof(float), xRoot);
            StringReader stringReader = new StringReader(xmlString);

            float baseRateValue = (float)serializer.Deserialize(stringReader);

            return baseRateValue;
        }
    }
}