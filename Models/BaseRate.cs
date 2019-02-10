using System;

namespace RateEvaluator.SharedModels
{
    public class BaseRate
    {
        public enum RateType
        {
            VILIBIDovernight = 0,
            VILIBID1w = 1,
            VILIBID2w = 2,
            VILIBID1m = 3,
            VILIBID3m = 4,
            VILIBID6m = 5,
            VILIBID1y = 6,
            VILIBORovernight = 7,
            VILIBOR1w = 8,
            VILIBOR2w = 9,
            VILIBOR1m = 10,
            VILIBOR3m = 11,
            VILIBOR6m = 12,
            VILIBOR1y = 13
        }

        public int Id { get; set; }

        public RateType Code { get; set; }
        public float Value { get; set; }
        public DateTime Date { get; set; }

        public BaseRate() { } // for serialization

        public BaseRate(RateType code, float value, DateTime date)
        {
            this.Code = code;
            this.Value = value;
            this.Date = date;
        }
    }
}