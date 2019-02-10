using RateEvaluator.BusinessLogic;
using RateEvaluator.Data;
using RateEvaluator.SharedModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace RateEvaluator.Controllers
{
    public class RatesController : ApiController
    {
        private IRatesDatabaseContext db = new RatesDatabaseContext();

        public RatesController() { }

        public RatesController(IRatesDatabaseContext dbContext)
        {
            db = dbContext;
        }

        // GET api/rates
        // returns XML containing the list of agreements
        public IEnumerable<Agreement> Get()
        {
            IEnumerable<Agreement> agreements = db.Agreements.Include("Customer");

            return agreements;
        }

        // GET api/rates/5
        public Agreement Get(int id)
        {
            return db.Agreements.Include("Customer").SingleOrDefault(x => x.Id == id);
        }

        // PUT api/rates/5
        [HttpPut]
        public AgreementExtended Put(int id, [FromBody]BaseRate.RateType newBaseRateType)
        {
            Agreement agreement = db.Agreements.Include("Customer").Single(x => x.Id == id);
            BaseRate.RateType oldBaseRateType = agreement.BaseRateType;
            agreement.BaseRateType = newBaseRateType;

            db.MarkAsModified(agreement);
            db.SaveChanges();

            // TODO: check if base rate record exists

            float currentBaseRateValue = db.BaseRates.Single(x => x.Code == oldBaseRateType).Value;
            float newBaseRateValue = db.BaseRates.Single(x => x.Code == newBaseRateType).Value;

            agreement.BaseRateType = oldBaseRateType;
            var agremeentExtended = Agreements.GetExtendedAgreement(agreement, newBaseRateType, currentBaseRateValue, newBaseRateValue);
    
            return agremeentExtended;
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
