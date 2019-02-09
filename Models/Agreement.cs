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
        public BaseRate BaseRate { get; set; }
        [DataMember]
        public float Margin { get; private set; }
        [DataMember]
        public int Duration { get; set; }
        [DataMember]
        public Customer Customer { get; set; }

        public Agreement() { } // for serialization

        public Agreement(int id, int amount, BaseRate baseRate, float margin, int duration, Customer customer)
        {
            this.Id = id;
            this.Amount = amount;
            this.BaseRate = baseRate;
            this.Margin = margin;
            this.Duration = duration;
            this.Customer = customer;
        }
    }
}