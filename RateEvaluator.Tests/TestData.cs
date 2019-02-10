using RateEvaluator.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateEvaluator.Tests
{
    public class TestData
    {
        public static Customer GetTestCustomer()
        {
            var customer = new Customer(1, "John", "Smith");

            return customer;
        }

        public static Agreement GetTestAgreement1(Customer customer, BaseRate.RateType baseRateType)
        {
            //var customer = GetTestCustomer();

            var agreement = new Agreement(100, baseRateType, 1.5f, 10, customer);
            agreement.Id = 1;
            agreement.CustomerId = customer.Id;

            return agreement;
        }

        public static Agreement GetTestAgreement2(Customer customer, BaseRate.RateType baseRateType)
        {
            //var customer = GetTestCustomer();

            var agreement = new Agreement(200, baseRateType, 2.5f, 20, customer);
            agreement.Id = 2;
            agreement.CustomerId = customer.Id;

            return agreement;
        }

        public static BaseRate GetTestBaseRate1()
        {
            return new BaseRate(BaseRate.RateType.VILIBID1m, 1.5f, DateTime.Today);
        }

        public static BaseRate GetTestBaseRate2()
        {
            return new BaseRate(BaseRate.RateType.VILIBORovernight, 2.5f, DateTime.Today);
        }
    }
}
