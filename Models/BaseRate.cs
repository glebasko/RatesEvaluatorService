using System;

namespace RateEvaluator.SharedModels
{
    public class BaseRate
    {
        public enum RateType
        {
            VILIBIDovernight,
            VILIBID1w,
            VILIBID2w,
            VILIBID1m,
            VILIBID3m,
            VILIBID6m,
            VILIBID1y,
            VILIBORovernight,
            VILIBOR1w,
            VILIBOR2w,
            VILIBOR1m,
            VILIBOR3m,
            VILIBOR6m,
            VILIBOR1y
        }

        public int Id { get; set; }

        public RateType Code { get; set; }
        public float Value { get; set; }
        public DateTime Date { get; set; }

        public BaseRate() { } // for serialization

        public BaseRate(int id, RateType code, float value)
        {
            this.Id = id;
            this.Code = code;
            this.Value = value;
        }
    }
}