using RateEvaluator.SharedModels;
using System.Data.Entity;

namespace RateEvaluator.Data
{
    public class RatesDatabaseContext : DbContext, IRatesDatabaseContext
    {
        public RatesDatabaseContext() : base("name=RatesDatabaseContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Agreement> Agreements { get; set; }
        public DbSet<BaseRate> BaseRates { get; set; }

        public void MarkAsModified(Agreement agreement)
        {
            Entry(agreement).State = EntityState.Modified;
        }

        public void MarkAsModified(Customer customer)
        {
            Entry(customer).State = EntityState.Modified;
        }

        public void MarkAsModified(BaseRate baseRate)
        {
            Entry(baseRate).State = EntityState.Modified;
        }
    }
}