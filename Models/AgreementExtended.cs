using RateEvaluator.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RateEvaluator.SharedModels
{
    public class AgreementExtended : Agreement
    {
        [DataMember]
        public float CurrentInterestRate { get; set; }
        [DataMember]
        public float NewInterestRate { get; set; }
        [DataMember]
        public float DifferenceBetweenInterestRates { get; set; }
        [DataMember]
        public BaseRate.RateType NewBaseRateType { get; set; }

        public AgreementExtended() { }

        public AgreementExtended (Agreement agreement, BaseRate.RateType newBaseRateType) : 
            base(agreement.Amount, agreement.BaseRateType, agreement.Margin, agreement.Duration, agreement.Customer)
        {
            this.Id = agreement.Id;
            this.CustomerId = this.Customer.Id; // this line is required as we are not using EF to map to foreign key
            this.NewBaseRateType = newBaseRateType;
        }
    }
}
