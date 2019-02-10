using System;
using System.Data.Entity;

namespace RateEvaluator.SharedModels 
{
    public interface IRatesDatabaseContext : IDisposable
    {
        DbSet<Customer> Customers { get; }
        DbSet<Agreement> Agreements { get; }
        DbSet<BaseRate> BaseRates { get; }

        int SaveChanges();

        void MarkAsModified(Agreement item);
        void MarkAsModified(Customer item);
        void MarkAsModified(BaseRate item);
    }
}
