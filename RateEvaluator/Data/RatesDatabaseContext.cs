using RateEvaluator.SharedModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RateEvaluator.Data
{
    public class RatesDatabaseContext : DbContext
    {
        public RatesDatabaseContext() : base("name=RatesDatabaseContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Agreement> Agreements { get; set; }
        public DbSet<BaseRate> BaseRates { get; set; }
    }
}