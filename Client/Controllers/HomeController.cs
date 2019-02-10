using RateEvaluator.SharedModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetAgreementsList()
        {
            IEnumerable<Agreement> agreements = await ApiCalls.GetAgreementsAsync("api/rates");

            return PartialView("_AgreementsList", agreements);
        }

        public async Task<ActionResult> EditAgreement(int id)
        {
            Agreement agreement = await ApiCalls.GetAgreementAsync($"api/rates/{id}");

            return View(agreement);
        }

        [HttpPost]
        public async Task<ActionResult> EditAgreement(int id, BaseRate.RateType newBaseRateType)
        {
            AgreementExtended agreementExtended = await ApiCalls.UpdateAgreementBaseRate($"api/rates/{id}", newBaseRateType);

            return View("AgreementExtended", agreementExtended);
        }
    }
}