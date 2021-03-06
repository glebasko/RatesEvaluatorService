﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
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
        public long CustomerId { get; set; }

        [DataMember]
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public Agreement() { }

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