using RateEvaluator.BusinessLogic;
using RateEvaluator.Data;
using RateEvaluator.SharedModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
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
        /// <summary>
        /// returns XML containing a list of all agreements
        /// </summary>
        public IEnumerable<Agreement> GetAllAgreements()
        {
            IEnumerable<Agreement> agreements = db.Agreements.Include("Customer");

            return agreements;
        }

        // GET api/rates/{id}
        /// <summary>
        /// Finds and returns an agreement by id
        /// </summary>
        public IHttpActionResult GetAgreement(int id)
        {
            Agreement agreement = db.Agreements.Include(i => i.Customer).SingleOrDefault(x => x.Id == id);
            if (agreement == null)
            {
                return NotFound();
            }

            return Ok(agreement);
        }

        // PUT api/rates/{id}
        /// <summary>
        /// Updates an agreement, calculates the current and new interest rates and returns AgreementExtended object
        /// </summary>
        [HttpPut]
        public IHttpActionResult UpdateAgreement(int id, [FromBody]BaseRate.RateType newBaseRateType)
        {
            Agreement agreement = db.Agreements.Include("Customer").SingleOrDefault(x => x.Id == id);
            if (agreement == null)
            {
                return NotFound();
            }

            BaseRate.RateType oldBaseRateType = agreement.BaseRateType;
            agreement.BaseRateType = newBaseRateType;

            db.MarkAsModified(agreement);

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            // check if base rate record exists

            BaseRate currentBaseRate = db.BaseRates.SingleOrDefault(x => x.Code == oldBaseRateType);
            BaseRate newBaseRate = db.BaseRates.SingleOrDefault(x => x.Code == newBaseRateType);
            if(currentBaseRate == null || newBaseRate == null)
            {
                // Better solution would be to throw a custom exception with an error message    
                      
                return InternalServerError(new ArgumentNullException("Base Rate record was not found"));
            }

            // to client we need to return an agreement with an old base rate type
            agreement.BaseRateType = oldBaseRateType;

            var agremeentExtended = Agreements.GetExtendedAgreement(agreement, newBaseRateType, currentBaseRate.Value, newBaseRate.Value);

            return Ok(agremeentExtended);
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
