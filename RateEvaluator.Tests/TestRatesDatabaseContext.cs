﻿using RateEvaluator.SharedModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateEvaluator.Tests
{
    public class TestRatesDatabaseContext : IRatesDatabaseContext
    {
        public TestRatesDatabaseContext()
        {
            this.Agreements = new TestDbSet<Agreement>();
            this.Customers = new TestDbSet<Customer>();
            this.BaseRates = new TestDbSet<BaseRate>();
        }

        public DbSet<Agreement> Agreements { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BaseRate> BaseRates { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Agreement agreement) { }
        public void MarkAsModified(Customer customer) { }
        public void MarkAsModified(BaseRate baseRate) { }

        public void Dispose() { }
    }
}
