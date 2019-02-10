using RateEvaluator.Data;
using RateEvaluator.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace RateEvaluator
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            SetDataDirectory();
            SeedDatabase();

            IEnumerable<BaseRate> baseRates = BaseRatesImporter.ImportLatestBaseRatesAsync().GetAwaiter().GetResult();
            SaveBaseRatesToDb(baseRates);
        }      

        // seed database with initial data
        private void SeedDatabase()
        {
            using (var db = new RatesDatabaseContext())
            {
                if (db.Customers.Count() > 0)
                {
                    return;
                }

                Customer customer1 = new Customer(67812203006, "Goras", "Trusevičius");
                Customer customer2 = new Customer(78706151287, "Dange", "Kulkavičiutė");
                db.Customers.Add(customer1);
                db.Customers.Add(customer2);

                db.Agreements.Add(new Agreement(12000, BaseRate.RateType.VILIBOR3m, 1.6f, 60, customer1));
                db.Agreements.Add(new Agreement(8000, BaseRate.RateType.VILIBOR1y, 0.42f, 36, customer2));
                db.Agreements.Add(new Agreement(1000, BaseRate.RateType.VILIBOR6m, 1.85f, 24, customer2));

                db.SaveChanges();
            }
        }

        private void SetDataDirectory()
        {
            string projectRootDirectory = HttpRuntime.AppDomainAppPath;
            AppDomain.CurrentDomain.SetData("DataDirectory", $"{projectRootDirectory}Data");
        }

        private void SaveBaseRatesToDb(IEnumerable<BaseRate> baseRates)
        {
            using (var db = new RatesDatabaseContext())
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE [BaseRates]");
                db.BaseRates.AddRange(baseRates);
                db.SaveChanges();
            }
        }
    }
}
