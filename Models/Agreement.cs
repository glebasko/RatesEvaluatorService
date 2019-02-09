using System;
using System.Runtime.Serialization;

namespace RateEvaluator.SharedModels
{

    [DataContract]
    public class Agreement
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Amount { get; set; }
        [DataMember]
        public BaseRate.RateType BaseRateType { get; set; }
        [DataMember]
        public float Margin { get; private set; } // setter is required to allow serialization
        [DataMember]
        public int Duration { get; set; }
        [DataMember]
        public Customer Customer { get; set; }

        public Agreement() { } // for serialization

        public Agreement(int id, int amount, BaseRate.RateType baseRateType, float margin, int duration, Customer customer)
        {
            this.Id = id;
            this.Amount = amount;
            this.BaseRateType = baseRateType;
            this.Margin = margin;
            this.Duration = duration;
            this.Customer = customer;
        }

        public Agreement(int amount, BaseRate.RateType baseRateType, float margin, int duration, Customer customer)
        {
            this.Amount = amount;
            this.BaseRateType = baseRateType;
            this.Margin = margin;
            this.Duration = duration;
            this.Customer = customer;
        }
    }
}