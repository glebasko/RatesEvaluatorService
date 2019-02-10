using RateEvaluator.SharedModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateEvaluator.SharedModels 
{
    public interface IRatesDatabaseContext : IDisposable
    {
        DbSet<Customer> Customers { get; }
        DbSet<Agreement> Agreements { get; }
        DbSet<BaseRate> BaseRates { get; }

        int SaveChanges();
        void MarkAsModified(Agreement item);
    }
}
