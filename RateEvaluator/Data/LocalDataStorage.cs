using RateEvaluator.SharedModels;
using System.Collections.Generic;

namespace RateEvaluator.Data
{
    public static class LocalDataStorage
    {
        public static List<Customer> Customers { get; set; }
        public static List<Agreement> Agreements { get; set; }
        public static List<BaseRate> BaseRates { get; set; }

        public static void Init()
        {
            BaseRates = new List<BaseRate>();
            BaseRate baseRate1 = new BaseRate(1, BaseRate.RateType.VILIBOR3m, 0.18f);
            BaseRate baseRate2 = new BaseRate(2, BaseRate.RateType.VILIBOR1y, 0.42f);
            BaseRate baseRate3 = new BaseRate(3, BaseRate.RateType.VILIBOR6m, 0.27f);
            BaseRates.Add(baseRate1);
            BaseRates.Add(baseRate2);
            BaseRates.Add(baseRate3);

            Customers = new List<Customer>();
            Customer customer1 = new Customer(67812203006, "Goras", "Trusevičius");
            //customer1.Agreements.Add(agreement1);
            Customer customer2 = new Customer(78706151287, "Dange", "Kulkavičiutė");
            //customer2.Agreements.Add(agreement2);
            //customer2.Agreements.Add(agreement3);
            Customers.Add(customer1);
            Customers.Add(customer2);

            Agreements = new List<Agreement>();
            Agreement agreement1 = new Agreement(1, 12000, baseRate1, 1.6f, 60, customer1);
            Agreement agreement2 = new Agreement(2, 8000, baseRate2, 2.2f, 36, customer2);
            Agreement agreement3 = new Agreement(3, 1000, baseRate3, 1.85f, 24, customer2);
            Agreements.Add(agreement1);
            Agreements.Add(agreement2);
            Agreements.Add(agreement3);
        }
    }
}