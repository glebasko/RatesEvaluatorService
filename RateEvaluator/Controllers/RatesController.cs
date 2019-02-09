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
        private RatesDatabaseContext db = new RatesDatabaseContext();

        // GET api/rates
        // returns XML containing the list of agreements
        public IEnumerable<Agreement> Get()
        {
            return db.Agreements;
        }

        // GET api/rates/5
        public Agreement Get(int id)
        {
            return db.Agreements.SingleOrDefault(x => x.Id == id);
        }

        // PUT api/rates/5
        public string Put(int id, [FromBody]BaseRate.RateType newBaseRateType)
        {
            // calculate new interest base rate and return custom xml

            return "Not implemented";
        }

        // disposes dbcontext
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
