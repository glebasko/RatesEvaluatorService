using Microsoft.VisualStudio.TestTools.UnitTesting;
using RateEvaluator.Controllers;
using RateEvaluator.SharedModels;
using System.Web.Http.Results;
using System.Net;
using System;

namespace RateEvaluator.Tests
{
    [TestClass]
    public class TestRatesController
    {
        [TestMethod]
        public void Test_GetAgreements()
        {
            var db = new TestRatesDatabaseContext();

            var customer = new Customer(1, "John", "Smith");

            db.Agreements.Add(new Agreement(100, BaseRate.RateType.VILIBID1m, 1.5f, 10, customer));
            db.Agreements.Add(new Agreement(200, BaseRate.RateType.VILIBIDovernight, 2.5f, 20, customer));

            var ratesController = new RatesController(db);
            var result = ratesController.Get() as TestDbSet<Agreement>;

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Local.Count);
        }
    }
}
