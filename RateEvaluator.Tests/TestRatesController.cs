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

            var agreement1 = TestData.GetTestAgreement1(TestData.GetTestCustomer(), TestData.GetTestBaseRate1().Code);
            var agreement2 = TestData.GetTestAgreement2(TestData.GetTestCustomer(), TestData.GetTestBaseRate2().Code);

            db.Agreements.Add(agreement1);
            db.Agreements.Add(agreement2);

            var ratesController = new RatesController(db);
            var result = ratesController.GetAllAgreements() as TestDbSet<Agreement>;

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Local.Count);
        }

        [TestMethod]
        public void Test_ShouldReturnEmptyAgreementsList()
        {
            var db = new TestRatesDatabaseContext();

            var ratesController = new RatesController(db);
            var result = ratesController.GetAllAgreements() as TestDbSet<Agreement>;

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Local.Count);
        }

        [TestMethod]
        public void Test_ShouldReturnAgreementByTheSameId()
        {
            var db = new TestRatesDatabaseContext();

            Agreement agreement = TestData.GetTestAgreement1(TestData.GetTestCustomer(), TestData.GetTestBaseRate1().Code);
            db.Agreements.Add(agreement);

            Assert.AreEqual(1, db.Agreements.Local.Count);

            var ratesController = new RatesController(db);
            Agreement resultAgreement = ratesController.GetAgreement(agreement.Id);

            Assert.IsNotNull(resultAgreement);
            Assert.AreEqual(agreement.Id, resultAgreement.Id);
        }

        [TestMethod]
        public void Test_ShouldNotReturnAgreement()
        {
            var db = new TestRatesDatabaseContext();

            Agreement agreement = TestData.GetTestAgreement1(TestData.GetTestCustomer(), TestData.GetTestBaseRate1().Code);
            db.Agreements.Add(agreement);

            Assert.AreEqual(1, db.Agreements.Local.Count);

            var ratesController = new RatesController(db);
            Agreement resultAgreement = ratesController.GetAgreement(agreement.Id++);

            Assert.IsNull(resultAgreement);
        }

        [TestMethod]
        public void Test_ShouldUpdateAgreement()
        {
            var db = new TestRatesDatabaseContext();

            var agreement = TestData.GetTestAgreement1(TestData.GetTestCustomer(), TestData.GetTestBaseRate1().Code);
            db.Agreements.Add(agreement);

            Assert.AreEqual(1, db.Agreements.Local.Count);

            // Put depends on Base Rate values
            // For that we need to add them to db

            var baseRate1 = TestData.GetTestBaseRate1();
            var baseRate2 = TestData.GetTestBaseRate2();
            db.BaseRates.Add(baseRate1);
            db.BaseRates.Add(baseRate2);

            Assert.AreEqual(2, db.BaseRates.Local.Count);

            var ratesController = new RatesController(db);

            AgreementExtended agreementExtended = ratesController.UpdateAgreement(agreement.Id, baseRate2.Code);

            Assert.AreEqual(agreement.Id, agreementExtended.Id);
            Assert.AreEqual(baseRate2.Code, agreementExtended.NewBaseRateType);
        }
    }
}
