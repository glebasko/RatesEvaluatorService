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

        public static Agreement GetTestAgreement1()
        {
            var customer = GetTestCustomer();

            var agreement = new Agreement(100, BaseRate.RateType.VILIBID1m, 1.5f, 10, customer);
            agreement.Id = 1;
            agreement.CustomerId = customer.Id;

            return agreement;
        }

        public static Agreement GetTestAgreement2()
        {
            var customer = GetTestCustomer();

            var agreement = new Agreement(200, BaseRate.RateType.VILIBIDovernight, 2.5f, 20, customer);
            agreement.Id = 2;
            agreement.CustomerId = customer.Id;

            return agreement;
        }

        //public static BaseRate.RateType GetTestBaseRateType1()
        //{

        //    return null;
        //}

        //public static BaseRate.RateType GetTestBaseRateType2()
        //{

        //    return null;
        //}
    }
}
