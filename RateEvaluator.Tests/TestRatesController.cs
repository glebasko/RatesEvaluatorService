using Microsoft.VisualStudio.TestTools.UnitTesting;
using RateEvaluator.Controllers;
using RateEvaluator.SharedModels;
using System;

namespace RateEvaluator.Tests
{
    [TestClass]
    public class TestRatesController
    {
        [TestMethod]
        public void Test_ShouldReturnNotEmptyAgreementsList()
        {
            var db = new TestRatesDatabaseContext();

            db.Agreements.Add(TestData.GetTestAgreement1());
            db.Agreements.Add(TestData.GetTestAgreement2());

            var ratesController = new RatesController(db);
            var result = ratesController.Get() as TestDbSet<Agreement>;

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Local.Count);
        }

        [TestMethod]
        public void Test_ShouldReturnEmptyAgreementsList()
        {
            var db = new TestRatesDatabaseContext();

            var ratesController = new RatesController(db);
            var result = ratesController.Get() as TestDbSet<Agreement>;

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Local.Count);
        }

        [TestMethod]
        public void Test_ShouldReturnAgreementByTheSameId()
        {
            var db = new TestRatesDatabaseContext();

            Agreement agreement = TestData.GetTestAgreement1();

            db.Agreements.Add(agreement);

            var ratesController = new RatesController(db);
            var resultAgreement = ratesController.Get(agreement.Id) as Agreement;

            Assert.IsNotNull(resultAgreement);
            Assert.AreEqual(resultAgreement.Id, agreement.Id);
        }

        [TestMethod]
        public void Test_ShouldNotReturnAgreement()
        {
            var db = new TestRatesDatabaseContext();

            Agreement agreement = TestData.GetTestAgreement1();

            db.Agreements.Add(agreement);

            var ratesController = new RatesController(db);
            var resultAgreement = ratesController.Get(agreement.Id++) as Agreement;

            Assert.IsNull(resultAgreement);
        }

        //[TestMethod]
        //public void Test_ShouldUpdateAgreement()
        //{
        //    var db = new TestRatesDatabaseContext();

        //    var agreement = TestData.GetTestAgreement1();

        //    var ratesController = new RatesController(db);

        //    ratesController.Put(agreement.Id, BaseRate.RateType.VILIBID1m);
        //}
    }
}
