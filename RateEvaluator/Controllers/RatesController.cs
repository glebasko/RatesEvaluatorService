using RateEvaluator.Data;
using RateEvaluator.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RateEvaluator.Controllers
{
    public class RatesController : ApiController
    {
        // GET api/values
        // returns XML containing the list of agreements
        public IEnumerable<Agreement> Get()
        {
            return LocalDataStorage.Agreements;
        }

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // PUT api/values/5
        public string Put(int id, [FromBody]BaseRate.RateType newBaseRateType)
        {
            // calculate new interest base rate and return custom xml

            return "Not implemented";
        }

    }
}
