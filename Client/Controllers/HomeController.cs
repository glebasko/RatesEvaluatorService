using RateEvaluator.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
            IEnumerable<Agreement> agreements = await ApiCalls.GetAgreements("api/rates");

            return PartialView("_AgreementsList", agreements);
        }

        public async Task<ActionResult> EditAgreement(int id)
        {
            Agreement agreement = await ApiCalls.GetAgreement($"api/rates/{id}");

            return View(agreement);
        }
    }
}